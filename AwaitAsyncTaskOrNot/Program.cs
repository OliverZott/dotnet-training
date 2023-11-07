// https://www.youtube.com/watch?v=aaC16Fv2zes

using AwaitAsyncTaskOrNot;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(new[] { typeof(ValBenchmark) });