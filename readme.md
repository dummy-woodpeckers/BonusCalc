Background:
Users of our application can have several currency accounts (EUR, USD, etc.).
Moreover, each user by default can have a bonus account in one currency (let it be USD).
Wirex has a rewards program and gives some bonuses under certain conditions, for example, this can be a
cashback.

These bonuses are put into the bonus accounts.

Task:
Given the user with several accounts. The user can load money or spend from accounts.
The task is to implement the C# code (only object model) to calculate and pay bonuses to the user's bonus
account.

Let's assume that for now, we can give bonuses when:
- the user spends more than 5 currency units (5 USD, 5 EUR, etc.) from the account (1% bonus)
- makes 10+ spend operations per day (additional 1% of total amount)

We also might add new reward programs in the future.
To calculate the bonus in target currency we need to exchange it from the account currency (EUR for
example) to bonus account currency (USD in our case).

For this task - just keep exchange rates hardcoded in-memory.

Notes:
The implementation should be a fully working solution, covered by unit tests.
This task doesn't require implementing any web, mobile application or database.
As a guideline, please aim to spend about 3 hours working on the solution for this task.
The task and / or solution shouldn’t be publicly shared, eg. using your GitHub profile or other channels