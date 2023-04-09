# Async Examples

- [Asynchronous programming with async and await](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/#dont-block-await-instead)
- [Asynchronous programming patterns](https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/)

### await

- [doc](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await)
- The await operator suspends the calling method and yields control back to its caller until the awaited task is
  complete.
- The await keyword provides a non-blocking way to start a task, then continue execution when that task completes.

### Task

- [doc](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-7.0)
- A Task object typically executes asynchronously on a thread pool thread rather than synchronously on the main
  application thread.
- You start a task and hold on to the Task object that represents the work. You'll await each task before working with
  its result.