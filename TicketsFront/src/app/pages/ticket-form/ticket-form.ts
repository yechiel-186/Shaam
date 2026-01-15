import { Component } from '@angular/core';
import { ApiService } from '../../services/api';
import { Ticket } from '../../models/ticket.model';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ticket-form',
  imports: [ReactiveFormsModule],
  templateUrl: './ticket-form.html',
  styleUrl: './ticket-form.scss',
})
export class TicketFormComponent {
  ticketForm!: FormGroup;
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit() {
    this.ticketForm = new FormGroup({
      subject: new FormControl(''),
      description: new FormControl(''),
      userId: new FormControl(0)
    });
  }

  Submit() {
    const ticket: Ticket = this.ticketForm.value as Ticket;    
    this.apiService.createTicket(ticket).subscribe(response => {
      this.router.navigate(['/tickets-list']);
    });
  }
}
