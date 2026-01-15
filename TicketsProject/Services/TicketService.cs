public class TicketService
{
    private readonly List<Ticket> _tickets = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public TicketService()
    {
        _tickets.Add(new Ticket(
            Id: _nextId++,
            UserId: 123456789,
            Subject: "בעיה בהתחברות ",
            Description: "לא מצליח להתחבר למערכת",
            IsClosed: false
        ));

        _tickets.Add(new Ticket(
            Id: _nextId++,
            UserId: 987654321,
            Subject: "שאלה לגבי חשבון",
            Description: "איך משנים את פרטי החשבון?",
            IsClosed: true
        ));

        _tickets.Add(new Ticket(
                Id: _nextId++,
                UserId: 555555555,
                Subject: "בקשה לתמיכה טכנית",
                Description: "המחשב שלי לא מגיב.",
                IsClosed: false
        ));

        _tickets.Add(new Ticket(
                Id: _nextId++,
                UserId: 111222333,
                Subject: "דיווח על באג",
                Description: "האתר קורס כשאני מנסה להעלות קובץ.",
                IsClosed: true
        ));
    }

    public List<Ticket> GetAllTickets()
    {
        lock (_lock)
        {
            return _tickets.ToList();
        }
    }

    public Ticket CreateTicket(int userId, string subject, string description)
    {
        lock (_lock)
        {
            var ticket = new Ticket(
                Id: _nextId++,
                UserId: userId,
                Subject: subject,
                Description: description,
                IsClosed: false
            );
            
            _tickets.Add(ticket);
            return ticket;
        }
    }

    public Ticket? CloseTicket(int ticketId, bool closed)
    {
        lock (_lock)
        {
            var index = _tickets.FindIndex(t => t.Id == ticketId);
            
            if (index == -1)
            {
                return null;
            }
            
            var oldTicket = _tickets[index];
            var closedTicket = oldTicket with { IsClosed = closed };
            _tickets[index] = closedTicket;
            
            return closedTicket;
        }
    }
}