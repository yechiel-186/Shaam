import { Routes } from '@angular/router';
import { TicketFormComponent } from './pages/ticket-form/ticket-form';
import { TicketsListComponent } from './pages/tickets-list/tickets-list';

export const routes: Routes = [
    { path: '', redirectTo: '/ticket-form', pathMatch: 'full' },
    { path: 'ticket-form', component: TicketFormComponent },
    { path: 'tickets-list', component: TicketsListComponent }
];
