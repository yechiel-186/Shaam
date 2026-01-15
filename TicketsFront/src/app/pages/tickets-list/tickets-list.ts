import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit, signal, ViewChild } from '@angular/core';
import { Ticket } from '../../models/ticket.model';
import { ApiService } from '../../services/api';
import { CommonModule } from '@angular/common';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-tickets-list',
  imports: [CommonModule, MatSelectModule],
  standalone: true,
  templateUrl: './tickets-list.html',
  styleUrl: './tickets-list.scss',
})
export class TicketsListComponent implements OnInit {
  tickets = signal<Ticket[]>([]);
  displayedTickets = signal<Ticket[]>([]);
  constructor(private apiService: ApiService, private cd: ChangeDetectorRef) {  }

  ngOnInit() {
    this.getTickets();
  }

  getTickets() {
    this.apiService.getTickets().subscribe((data: Ticket[]) => {
      this.tickets.set([...data]);
      this.displayedTickets.set([...data]);
      this.cd.markForCheck();
    });
  }

  updateTicket(id: number, checked: boolean) {
    this.apiService.updateTicket(id, checked).subscribe(() => {
      this.getTickets();
    });
  }

  filterTickets(status: string) {
    if(status === 'all') {
      this.getTickets();
      return;
    }
    this.displayedTickets.set([...this.tickets().filter(ticket => {
      if (status === 'open') {
        return !ticket.isClosed;
      } else  {
        return ticket.isClosed;
      }
    })]);    
  }
  
}
