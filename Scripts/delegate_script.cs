var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// var even = numbers.Where(n => n % 2 == 0);

// create delegate instance first then pass it to the method like a variable (functionpointer stored in a variable)
// Where doesn’t build a new array immediately—it creates an iterator. When you later iterate over even, the predicate runs lazily on demand, yielding the elements that passed the test.
// Passing isEven into Where hands over the delegate—no call happens yet.
// Where builds an iterator that calls isEven for each element as soon as something enumerates over it.

Func<int, bool> isEven = n => n % 2 == 0;
var even = numbers.Where(isEven);

foreach (var number in even)
{
    Console.WriteLine(number);
}