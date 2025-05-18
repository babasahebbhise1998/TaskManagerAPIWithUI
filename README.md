# TaskManagerAPIWithUI
NET Developer Hiring Challenge

# Task Manager Application

A simple web-based Task Manager that allows you to add, edit, complete, and delete tasks.  
This frontend is a standalone HTML page that interacts with a backend REST API at `https://localhost:7180/api/tasks`.

---

## Prerequisites

- A modern web browser (Chrome, Firefox, Edge, Safari, etc.)
- A running backend API exposing the following endpoints (assumed to be implemented separately):
  - `GET /api/tasks` - Get all tasks
  - `GET /api/tasks/{id}` - Get task by ID
  - `POST /api/tasks` - Add a new task
  - `PUT /api/tasks/{id}` - Update a task
  - `DELETE /api/tasks/{id}` - Delete a task

- The backend API should be accessible at `https://localhost:7180/api/tasks`.  
  Adjust the `apiUrl` constant in the HTML if your API runs on a different URL or port.

---

## How to Run

1. **Backend API**  
   Make sure your backend API is running and accessible.

2. **Open the Frontend UI**  
   Simply open the `index.html` file (the HTML you have) in your web browser.  
   - The UI will connect to the backend API to load and manage tasks.

---

## Usage Instructions

- Fill in **Title** and **Description** and **Due Date** (both are required).
- Click **Add Task** to create a new task.
- Existing tasks show in the list below with options to:
  - **Complete** or **Undo** completion
  - **Edit** a task (fills the form for update)
  - **Delete** a task
- Click **Cancel Edit** to exit editing mode without saving.

---

## Assumptions, Shortcuts, and Trade-offs

- **Assumptions:**
  - The backend API implements all REST endpoints with JSON format.
  - The API supports CORS for your frontend to access it if opened locally.
  
- **Shortcuts:**
  - No build step is required; frontend is pure HTML + JS.
  - Both Client side and server side validation (Title and Description and Due Date are required).
  - Error handling is done via simple alert popups.
  
- **Trade-offs:**
  - UI and UX are minimal; no fancy styling beyond Bootstrap.
  - No user authentication or authorization implemented.
  - Due dates are handled as ISO strings but displayed as simple date.
  - No offline or local storage,
  - The frontend expects backend at a fixed URL (`https://localhost:7180/api/tasks`).

---

