# SpanUsageExample

This repository contains benchmark tests for comparing array operations with span operations in a .NET application.

## Benchmarks

### `ArrayOperations`

This benchmark class includes two methods for filling an array with values. One uses a traditional array loop, while the other utilizes the `Span<T>` type for the same purpose. The purpose of this benchmark is to compare the performance of the two approaches.

- `FillArray`: Fills an integer array with values using a traditional array loop.
- `FillArrayWithSpan`: Fills an integer array with values using a `Span<int>`.

## What Are Spans?

In .NET, a `Span<T>` is a lightweight stack-only data structure that represents a contiguous region of memory. Spans allow for efficient memory manipulation and are often used in scenarios where you need to work with slices of arrays, strings, or other data without unnecessary copying.

Spans offer improved performance and memory efficiency compared to traditional arrays when used correctly.

