import { Component, inject, OnInit, signal, Signal } from '@angular/core';
import { HotelService } from '../../core/services/hotel-service';
import { Hotel, HotelForm, RoomForm } from '../../models/hotel'; // Ensure consistent import path for Hotel type
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-hotel',
  imports: [FormsModule,NgIf,NgFor],
  templateUrl: './hotel.html',
  styleUrl: './hotel.css',
})
export class HotelComponent implements OnInit {
  private hotelService=inject(HotelService); 
  activeTab: 'add' | 'list' = 'add';
  submitted = false;
  isSaving = false;
  isLoading =signal(false);
  successMsg = '';
  errorMsg = '';
  timeOptions: string[] = [
    '12:00 AM', '1:00 AM', '2:00 AM', '3:00 AM',
    '4:00 AM', '5:00 AM', '6:00 AM', '7:00 AM',
    '8:00 AM', '9:00 AM', '10:00 AM', '11:00 AM',
    '12:00 PM', '1:00 PM', '2:00 PM', '3:00 PM',
    '4:00 PM', '5:00 PM', '6:00 PM', '7:00 PM', '8:00 PM'
    , '9:00 PM', '10:00 PM', '11:00 PM'
  ];

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
 
  hotelForm: HotelForm = this.blankForm();
  hotels=signal<Hotel[]>([]);
  ngOnInit(): void {
    const currentYear = new Date().getFullYear();
    for (let y = currentYear; y <= currentYear + 5; y++) {
      this.yearOptions.push(y);
    }
  }
  blankForm(): HotelForm {
    return { name: '', rooms: [] };
  }

  
 
  blankRoom(): RoomForm {
    return {
      name: '',
      timeSlots: [],
      selectedYear:  null,
      selectedMonth: null,
      selectedDay:   null,
      showPicker: false,
      slotError: '',
      newSlot: { from: '8:00 AM', to: '9:00 AM' }
    };
  }
 
  resetForm(): void {
    this.hotelForm = this.blankForm();
    this.submitted = false;
    this.successMsg = '';
    this.errorMsg = '';
  }
 
  trackByIndex(index: number): number {
    return index;
  }
 
  
 
  addRoom(): void {
    this.hotelForm.rooms.push(this.blankRoom());
  }
  getDaysInMonth(year: number, month: number): number[] {
    if (!year || !month) return [];
    const count = new Date(year, month, 0).getDate(); // e.g. Feb 2024 → 29
    return Array.from({ length: count }, (_, i) => i + 1);
  }
  removeRoom(index: number): void {
    this.hotelForm.rooms.splice(index, 1);
  }
 
  
 
  toggleSlotPicker(roomIndex: number): void {
    this.hotelForm.rooms[roomIndex].showPicker = true;
    this.hotelForm.rooms[roomIndex].slotError = '';
  }
 
  confirmSlot(roomIndex: number): void {
    const room = this.hotelForm.rooms[roomIndex];
    const { from, to } = room.newSlot;
 
   
    const fromIdx = this.timeOptions.indexOf(from);
    const toIdx = this.timeOptions.indexOf(to);
    if(fromIdx+1!==toIdx){
      room.slotError = 'Start Timing and End Timing should be 1 hour apart.';
      return;
    }
    if (fromIdx >= toIdx) {
      room.slotError = '"From" must be earlier than "To".';
      return;
    }
 
    // Duplicate check
    const duplicate = room.timeSlots.some(s => s.from === from && s.to === to);
    if (duplicate) {
      room.slotError = 'This time slot is already added.';
      return;
    }
 
    room.timeSlots.push({ from, to });
    room.showPicker = false;
    room.slotError = '';
    room.newSlot = { from: '8:00 AM', to: '9:00 AM' };
  }
 
  removeSlot(roomIndex: number, slotIndex: number): void {
    this.hotelForm.rooms[roomIndex].timeSlots.splice(slotIndex, 1);
  }
 
  
 
  saveHotel(): void {
    this.submitted = true;
    this.successMsg = '';
    this.errorMsg = '';
 
    if (!this.isFormValid()) return;
 
    this.isSaving = true;
 
    const payload:Hotel = {
      name: this.hotelForm.name,
      rooms: this.hotelForm.rooms.map(r => ({
        name: r.name,

        roomSlots: r.timeSlots.map(slot => ({
          startTime:new Date(r.selectedYear!, r.selectedMonth! - 1, r.selectedDay!),
        }))
      }))
    };
 
    this.hotelService.addHotel(payload).subscribe({
      next: () => {
        this.isSaving = false;
        this.successMsg = 'Hotel saved successfully.';
        this.resetForm();
      },
      error: (err) => {
        this.isSaving = false;
        this.errorMsg = 'Failed to save hotel. Please try again.';
        console.error(err);
      }
    });
  }
 
  isFormValid(): boolean {
    if (!this.hotelForm.name) return false;
    if (this.hotelForm.rooms.length === 0) return false;
    return this.hotelForm.rooms.every(
      r => r.name.trim() !== '' && !!r.selectedYear && !!r.selectedMonth && !!r.selectedDay
    );
  }
 
  
 
  loadHotels(): void {
    console.log('Loading hotels...');
    this.isLoading.set(true) ;
    this.hotelService.getHotels().subscribe({
      next: (data) => { this.hotels.set(data) ; this.isLoading.set(false) ; console.log('Hotels loaded:', data); },
      error: () => { this.isLoading.set(false); }
    });
  }
 
  getTotalSlots(hotel: Hotel): number {
    return hotel.rooms?.reduce((sum, r) => sum + (r.roomSlots?.length || 0), 0) ?? 0;
  }
 
  
 
  

  
}
