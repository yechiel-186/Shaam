export interface Ticket {
  id: number;
  subject: string;
  description: string;
  userId: number;
  isClosed?: boolean;
}