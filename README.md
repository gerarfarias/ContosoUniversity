# ContosoUniversity

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
