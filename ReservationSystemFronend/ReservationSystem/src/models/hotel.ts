export interface Hotel{
    
    name:string;
    rooms:Room[];

}

export interface HotelDetails{
    id:string
    name:string;
    rooms:Room[];
}



export interface Room{
    name:string;
    roomSlots:RoomSlots[];
}

export interface RoomSlots{
    startTime:Date;
}

export interface TimeSlot {
    from: string;
    to: string;
  }
   
  export interface RoomForm {
    name: string;
    timeSlots: TimeSlot[];
    selectedYear:  number | null;
    selectedMonth: number | null;
    selectedDay:   number | null;
    showPicker: boolean;
    slotError: string;
    newSlot: TimeSlot;
  }
   
  export interface HotelForm {
    name: string;
    rooms: RoomForm[];
  }