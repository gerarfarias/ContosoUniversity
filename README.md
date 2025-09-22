# ContosoUniversity
This project is an implementation of the Contoso University tutorial using ASP.NET Core MVC 9.0 and Entity Framework Core.
It demonstrates modern web application development patterns such as:

Building responsive UIs with shared layouts and partial views

Creating strongly-typed forms bound to models and view models

Applying CRUD (Create, Read, Update, Delete) functionality with EF Core

Using model binding and data annotations for validation

Implementing PRG (Post-Redirect-Get) with TempData for success messages

Adding sorting, filtering, and paging to list views

Following the MVC pattern to separate concerns and keep code organized

The focus is on learning how to structure an ASP.NET Core MVC application while ensuring responsiveness, accessibility, and maintainability.

## Test Plan
1. Navigate to `/Students/Create`
   - Leave fields blank → Validation messages should appear under each field.
   - Fill fields correctly → Form should redirect to `/Students/Index` and show success message.
2. Navigate to `/Students/Index`
   - Newly created student should be listed in the table.
   - Success message should display after Create/Edit actions.
3. Navigate to `/Students/Edit/{id}`
   - Change fields → Save → Redirect to Index with updated values visible.
4. Try invalid email format → Error message should display and form should not submit.
5. Check success messages use `TempData` and disappear after page refresh.
