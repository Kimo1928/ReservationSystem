import { Component, inject, signal } from '@angular/core';
import { TopicService } from '../../core/services/topic-service';
import { UserService } from '../../core/services/user-service';
import { User, UserDto } from '../../models/User';
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';

interface Topic {
  id: number;
  name: string;
}

interface TopicAvailabilityForm {
  topicId: number | null;
  year:    number | null;
  month:   number | null;
  day:     number | null;
  fromHour: string;
  toHour:   string;
}

interface PresenterForm {
  name:   string;
  mobile: string;
  topics: TopicAvailabilityForm[];
}

@Component({
  selector: 'app-presenter-component',
  imports: [FormsModule , NgIf,NgFor],
  templateUrl: './presenter-component.html',
  styleUrl: './presenter-component.css',
})
export class PresenterComponent {
  private userService  = inject(UserService);
  private topicService = inject(TopicService);

  // ── State ────────────────────────────────────────────────────────────────────
  activeTab: 'add' | 'list' = 'add';
  submitted  = false;
  isSaving =signal(false);
  successMsg = '';
  errorMsg   = '';

  presenters = signal<User[]>([]);
  topics    = signal<Topic[]>([]);
  isLoadingPresenters = signal(false);
  isLoadingTopics    = signal(false);

  // ── Options ──────────────────────────────────────────────────────────────────
  yearOptions: number[] = [];

  monthOptions = [
    { label: 'January',   value: 1  },
    { label: 'February',  value: 2  },
    { label: 'March',     value: 3  },
    { label: 'April',     value: 4  },
    { label: 'May',       value: 5  },
    { label: 'June',      value: 6  },
    { label: 'July',      value: 7  },
    { label: 'August',    value: 8  },
    { label: 'September', value: 9  },
    { label: 'October',   value: 10 },
    { label: 'November',  value: 11 },
    { label: 'December',  value: 12 },
  ];

  hourOptions: string[] = [
    '12:00 AM','1:00 AM','2:00 AM','3:00 AM','4:00 AM','5:00 AM',
    '6:00 AM','7:00 AM','8:00 AM','9:00 AM','10:00 AM','11:00 AM',
    '12:00 PM','1:00 PM','2:00 PM','3:00 PM','4:00 PM','5:00 PM',
    '6:00 PM','7:00 PM','8:00 PM','9:00 PM','10:00 PM','11:00 PM',
  ];

  // ── Form ─────────────────────────────────────────────────────────────────────
  presenterForm: PresenterForm = this.blankForm();

  ngOnInit(): void {
    const current = new Date().getFullYear();
    for (let y = current; y <= current + 5; y++) this.yearOptions.push(y);
    this.loadTopics();
  }

  blankForm(): PresenterForm {
    return { name: '', mobile: '', topics: [] };
  }

  blankTopic(): TopicAvailabilityForm {
    return { topicId: null, year: null, month: null, day: null, fromHour: '8:00 AM', toHour: '9:00 AM' };
  }

  resetForm(): void {
    this.presenterForm = this.blankForm();
    this.submitted  = false;
    this.successMsg = '';
    this.errorMsg   = '';
  }

  trackByIndex(i: number) { return i; }

  // ── Topics list ──────────────────────────────────────────────────────────────
  loadTopics(): void {
    this.isLoadingTopics.set(true);
    this.topicService.getAllTopics().subscribe({
      next: (data: any) => { this.topics.set(data); this.isLoadingTopics.set(false); },
      error: ()         => { this.isLoadingTopics.set(false); },
    });
  }

  getTopicName(id: number | null): string {
    return this.topics().find(t => t.id === id)?.name ?? '—';
  }

  // ── Topic rows ───────────────────────────────────────────────────────────────
  addTopic(): void    { this.presenterForm.topics.push(this.blankTopic()); }
  removeTopic(i: number): void { this.presenterForm.topics.splice(i, 1); }

  // ── Days helper ──────────────────────────────────────────────────────────────
  getDaysInMonth(year: number | null, month: number | null): number[] {
    if (!year || !month) return [];
    const count = new Date(year, month, 0).getDate();
    return Array.from({ length: count }, (_, i) => i + 1);
  }

  // ── Validation ───────────────────────────────────────────────────────────────
  isFormValid(): boolean {
    if (!this.presenterForm.name.trim())   return false;
    if (!this.presenterForm.mobile.trim()) return false;
    if (this.presenterForm.topics.length === 0) return false;
    return this.presenterForm.topics.every(t =>
      t.topicId && t.year && t.month && t.day && t.fromHour && t.toHour
    );
  }

  hasTimeIntersection(): boolean {
    const topics = this.presenterForm.topics;
    for (let i = 0; i < topics.length; i++) {
      for (let j = i + 1; j < topics.length; j++) {
        const a = topics[i];
        const b = topics[j];
  
        // Only check rows that are fully filled
        if (!a.year || !a.month || !a.day || !b.year || !b.month || !b.day) continue;
  
        const aFrom = new Date(a.year, a.month - 1, a.day, this.parseHour(a.fromHour));
        const aTo   = new Date(a.year, a.month - 1, a.day, this.parseHour(a.toHour));
        const bFrom = new Date(b.year, b.month - 1, b.day, this.parseHour(b.fromHour));
        const bTo   = new Date(b.year, b.month - 1, b.day, this.parseHour(b.toHour));
  
        // Overlap if one starts before the other ends, on the same date
        if (aFrom < aTo && bFrom < bTo && aFrom < bTo && bFrom < aTo) {
          return true;
        }
      }
    }
    return false;
  }

  // ── Save ─────────────────────────────────────────────────────────────────────
  savepresenter(): void {
    this.submitted  = true;
    this.successMsg = '';
    this.errorMsg   = '';
  
    if (!this.isFormValid()) return;
  
    // ── Intersection check ──────────────────────────────────────
    if (this.hasTimeIntersection()) {
      this.errorMsg = 'Time slots cannot overlap between sectors. Please fix the availability times.';
      return;
    }
  
    this.isSaving.set(true);
  
    const payload: UserDto = {
      name:     this.presenterForm.name,
      mobile:   this.presenterForm.mobile,
      userType: 3,
      userTopicAvaliabilityDTOs: this.presenterForm.topics.map(t => ({
        topicId:          t.topicId!,
        avaliabilityFrom: new Date(t.year!, t.month! - 1, t.day!,
                            this.parseHour(t.fromHour)).toISOString(),
                            avaliabilityTo:   new Date(t.year!, t.month! - 1, t.day!,
                            this.parseHour(t.toHour)).toISOString(),
      })),
    };
  
    this.userService.addUser(payload).subscribe({
      next: () => {
        this.isSaving.set(false);  
        this.successMsg = 'presenter saved successfully.';
        this.resetForm();
      },
      error: (err) => {
        this.isSaving.set(false);
        this.errorMsg = 'Failed to save presenter. Please try again.';
        console.error(err);
      },
    });
  }

  // ── Load presenters ───────────────────────────────────────────────────────────
  loadpresenters(): void {
    this.isLoadingPresenters.set(true);
    this.userService.getAllPresenters().subscribe({
      next: (data: any) => { this.presenters.set(data); this.isLoadingPresenters.set(false); },
      error: ()         => { this.isLoadingPresenters.set(false); },
    });
  }

  // ── Helpers ──────────────────────────────────────────────────────────────────
  parseHour(timeStr: string): number {
    const [time, period] = timeStr.split(' ');
    let [hours] = time.split(':').map(Number);
    if (period === 'PM' && hours !== 12) hours += 12;
    if (period === 'AM' && hours === 12) hours = 0;
    return hours;
  }

  formatDateTime(iso: string): string {
    if (!iso) return '—';
    const d = new Date(iso);
    return d.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
  }
}
