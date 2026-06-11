import { Component, inject, signal, computed, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReservationService } from '../../core/services/reservation-service';
import { UserService } from '../../core/services/user-service';
import { TopicService } from '../../core/services/topic-service';

interface Topic {
  id: number;
  name: string;
}

interface PresenterMatch {
  userId: number;
  name: string;
  mobile: string;
  overlapFrom: Date;
  overlapTo: Date;
}

interface RoomSlotDetails {
  roomSlotId: number;
  hotelName: string;
  roomName: string;
  startTime: Date;
  endTime: Date;
}

interface Reservation {
  reservationId?: number;
  investorName?: string;
  presenterName?: string;
  topicName?: string;
  roomName?: string;
  hotelName?: string;
  startTime?: Date;
  endTime?: Date;
}

@Component({
  selector: 'app-reservation',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './reservation-component.html',
})
export class ReservationComponent implements OnInit {
  private reservationService = inject(ReservationService);
  private userService = inject(UserService);
  private topicService = inject(TopicService);

  // ── Tab ──────────────────────────────────────────────────
  activeTab = signal<'new' | 'list'>('new');

  // ── Step tracking ────────────────────────────────────────
  currentStep = signal<1 | 2 | 3 | 4>(1);

  // ── Data lists ───────────────────────────────────────────
  investors = signal<any[]>([]);
  topics = signal<Topic[]>([]);
  matchingPresenters = signal<PresenterMatch[]>([]);
  availableSlots = signal<RoomSlotDetails[]>([]);
  reservations = signal<Reservation[]>([]);

  // ── Selections (signals) ─────────────────────────────────
  selectedInvestorId = signal<number | null>(null);
  selectedTopicId = signal<number | null>(null);
  selectedPresenterId = signal<number | null>(null);
  selectedSlotId = signal<number | null>(null);

  // ── Derived display helpers ──────────────────────────────
  selectedInvestor = computed(() =>
    this.investors().find(i => i.id === this.selectedInvestorId())
  );
  selectedTopic = computed(() =>
    this.topics().find(t => t.id === this.selectedTopicId())
  );
  selectedPresenter = computed(() =>
    this.matchingPresenters().find(p => p.userId === this.selectedPresenterId())
  );
  selectedSlot = computed(() =>
    this.availableSlots().find(s => s.roomSlotId === this.selectedSlotId())
  );

  // ── Loading / error states ───────────────────────────────
  loadingPresenters = signal(false);
  loadingSlots = signal(false);
  saving = signal(false);
  errorMessage = signal<string | null>(null);
  successMessage = signal<string | null>(null);

  // ── Lifecycle ────────────────────────────────────────────
  ngOnInit() {
    this.loadInvestors();
    this.loadTopics();
  }

  // ── Loaders ──────────────────────────────────────────────
  loadInvestors() {
    this.userService.getAllInvestors().subscribe({
      next: (data: any) => this.investors.set(data),
      error: () => this.setError('Failed to load investors.'),
    });
  }

  loadTopics() {
    this.topicService.getAllTopics().subscribe({
      next: (data: any) => { console.log('Loaded topics:', data);
        this.topics.set(Array.isArray(data) ? data : [data])},
      error: () => this.setError('Failed to load topics.'),
    });
  }

  // ── Step 1 → Step 2: investor + topic chosen ─────────────
  onInvestorChange(id: number) {
    this.selectedInvestorId.set(Number(id));
    this.resetFrom(2);
  }

  onTopicChange(id: number) {
    this.selectedTopicId.set(Number(id));
    this.resetFrom(2);
  }

  proceedToPresenters() {
    if (!this.selectedInvestorId() || !this.selectedTopicId()) return;
    this.loadingPresenters.set(true);
    this.matchingPresenters.set([]);
    this.errorMessage.set(null);

    this.userService
      .getMachingPresenters(this.selectedTopicId()!, this.selectedInvestorId()!)
      .subscribe({
        next: (data: any) => {
          this.matchingPresenters.set(Array.isArray(data) ? data : [data]);
          this.loadingPresenters.set(false);
          this.currentStep.set(2);
        },
        error: () => {
          this.setError('Failed to load matching presenters.');
          this.loadingPresenters.set(false);
        },
      });
  }

  // ── Step 2 → Step 3: presenter chosen ────────────────────
  selectPresenter(presenter: PresenterMatch) {
    this.selectedPresenterId.set(presenter.userId);
    this.loadingSlots.set(true);
    this.availableSlots.set([]);
    this.errorMessage.set(null);

    this.reservationService
      .getAvaliavleTimeSlots(
        presenter.userId,
        this.selectedTopicId()!,
        this.selectedInvestorId()!
      )
      .subscribe({
        next: (data: any) => {
          this.availableSlots.set(Array.isArray(data) ? data : [data]);
          this.loadingSlots.set(false);
          this.currentStep.set(3);
        },
        error: () => {
          this.setError('Failed to load available room slots.');
          this.loadingSlots.set(false);
        },
      });
  }

  // ── Step 3 → Step 4: slot chosen ─────────────────────────
  selectSlot(slot: RoomSlotDetails) {
    this.selectedSlotId.set(slot.roomSlotId);
    this.currentStep.set(4);
  }

  // ── Step 4: confirm reservation ──────────────────────────
  confirmReservation() {
    if (
      !this.selectedInvestorId() ||
      !this.selectedTopicId() ||
      !this.selectedPresenterId() ||
      !this.selectedSlotId()
    ) return;

    this.saving.set(true);
    this.errorMessage.set(null);

    const payload = {
      topicId: this.selectedTopicId(),
      investorId: this.selectedInvestorId(),
      presenterId: this.selectedPresenterId(),
      roomSlotId: this.selectedSlotId(),
    };

    this.reservationService.addReservation(payload).subscribe({
      next: (data: any) => {
        this.saving.set(false);
        // Add to local reservations list for display
        const slot = this.selectedSlot();
        const newReservation: Reservation = {
          reservationId: data?.reservationId ?? Date.now(),
          investorName: this.selectedInvestor()?.name,
          presenterName: this.selectedPresenter()?.name,
          topicName: this.selectedTopic()?.name,
          roomName: slot?.roomName,
          hotelName: slot?.hotelName,
          startTime: slot?.startTime,
          endTime: slot?.endTime,
        };
        this.reservations.update(r => [...r, newReservation]);
        this.successMessage.set('Reservation confirmed successfully!');
        this.resetForm();
        setTimeout(() => {
          this.activeTab.set('list');
          this.successMessage.set(null);
        }, 1500);
      },
      error: () => {
        this.setError('Failed to save reservation. Please try again.');
        this.saving.set(false);
      },
    });
  }

  // ── Navigation helpers ───────────────────────────────────
  goToStep(step: 1 | 2 | 3 | 4) {
    if (step < this.currentStep()) this.currentStep.set(step);
  }

  resetFrom(step: number) {
    if (step <= 2) {
      this.selectedPresenterId.set(null);
      this.matchingPresenters.set([]);
    }
    if (step <= 3) {
      this.selectedSlotId.set(null);
      this.availableSlots.set([]);
    }
    if (this.currentStep() > 1) this.currentStep.set(1);
  }

  resetForm() {
    this.selectedInvestorId.set(null);
    this.selectedTopicId.set(null);
    this.selectedPresenterId.set(null);
    this.selectedSlotId.set(null);
    this.matchingPresenters.set([]);
    this.availableSlots.set([]);
    this.currentStep.set(1);
  }

  // ── Utilities ────────────────────────────────────────────
  setError(msg: string) {
    this.errorMessage.set(msg);
    setTimeout(() => this.errorMessage.set(null), 4000);
  }

  formatDate(date: Date | string | undefined): string {
    if (!date) return '—';
    return new Date(date).toLocaleString('en-EG', {
      dateStyle: 'medium',
      timeStyle: 'short',
    });
  }

  formatTime(date: Date | string | undefined): string {
    if (!date) return '—';
    return new Date(date).toLocaleTimeString('en-EG', {
      hour: '2-digit',
      minute: '2-digit',
    });
  }
}