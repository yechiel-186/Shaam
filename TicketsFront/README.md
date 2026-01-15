## Quick start

1. Install dependencies
   npm install

2. Run dev server
   ng serve
   # open http://localhost:4200

## Backend API

This frontend expects an API at the URL configured in `src/app/services/api.ts` (default `http://localhost:5150`). Endpoints used:

- GET  /tickets         — list tickets
- POST /tickets         — create ticket
- PUT  /tickets/:id/close — close/open a ticket (payload: `{ isClosed: boolean }`)

## Server
