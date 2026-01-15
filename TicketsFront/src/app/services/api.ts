import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../models/ticket.model';

@Injectable({
  providedIn: 'root',
})

export class ApiService {
  url = 'http://localhost:5150';
  constructor(private http: HttpClient) {}
  
  getTickets() {
    return this.http.get<Ticket[]>(this.url + '/tickets');
  }

  createTicket(ticket: Ticket) {
    return this.http.post(this.url + '/tickets', ticket);
  }

  updateTicket(id: number, close: boolean) {
    return this.http.put(this.url + `/tickets/${id}/close`, { isClosed: close });
  }
}
