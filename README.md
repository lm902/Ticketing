# Ticketing API

Live API Base: http://106.52.154.91/api/

## Links

- [GitHub](https://github.com/lm902/Ticketing)
- [Doc](http://106.52.154.91)

![API description](https://i.imgur.com/RBD1xpe.png)

## Seeding

- Data has least 5 events, with over 100 seats each.

- Each event have 1 row completely sold already

- Each event have 2 other seats sold in one other test row

## Schemas

    Seat{
        id    string($uuid)
        name*    string
        price    number($double)
        rowId*    string($uuid)
    }
    Row{
        id    string($uuid)
        name*    string
        seats    [...]
        sectionId*    string($uuid)
    }
    Section{
        id    string($uuid)
        name*    string
        rows    [...]
        venueId*    string($uuid)
    }
    Venue{
        id    string($uuid)
        name*    string
        capacity    integer($int32)
        nullable: true
        sections    [...]
    }
    Event{
        id    string($uuid)
        name*    string
        venue*    {...}
        venueId    string($uuid)
    }
    EventSeat{
        id    string($uuid)
        seat*    {...}
        seatId    string($uuid)
        eventId*    string($uuid)
        price    number($double)
    }
    TicketPurchaseSeat{
        id    string($uuid)
        eventSeat*    {...}
        eventSeatId    string($uuid)
        subtotal    number($double)
        ticketPurchaseId*    string($uuid)
    }
    TicketPurchase{
        id    string($uuid)
        paymentMethod*    string
        paymentAmount    number($double)
        confirmationCode    string
        nullable: true
        ticketPurchaseSeats    [...]
    }