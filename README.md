# Reducing Garbage Collector Pressure
### 1-Set initial capacity for dynamic collections
.NET offers a plethora of valuable collection types, including List<T>, Dictionary<T>, and HashSet<T>, all of which possess dynamic capacity. This implies that they expand their size automatically as you introduce more elements.

Although this feature is quite convenient, it isn't ideal for efficient memory management. Each time a collection approaches its capacity limit, it will necessitate the allocation of a new, larger memory buffer (typically an array twice the size). Consequently, this entails an extra round of memory allocation and deallocation.

#### See the Benchmarks on IteratingDynamicCollectionOperations

### 2. Use ArrayPool for short-lived large arrays

Allocating and deallocating arrays can be expensive. Doing this frequently can slow down your program.

The System.Buffers.ArrayPool class in the Systems.Buffers NuGet package offers a smart solution. It's like a shared storage for arrays that you can reuse without wasting time on creating and destroying memory.

To use it, just call ArrayPool<T>.Shared.Rent(size) to get an array. After you're done, return it by calling ArrayPool<int>.Shared.Return(array). This helps keep your program efficient.

#### See the Benchmarks on ArrayPoolOperations

### 3. Use Structs instead of Classes (sometimes)

Structs have several advantages, especially in deallocation:

1. **Stack Allocation:**
   When structs are standalone (not part of a class), they're allocated on the stack, avoiding garbage collection (stack unwinding).

2. **Heap Storage for Structs in Classes:**
   If a struct is within a class (or any reference type), it's stored on the heap. However, it's stored inline and is deallocated when the containing type is deallocated. This inline storage is more efficient than reference types, which use a pointer to another heap location.

3. **Memory Efficiency:**
   Structs use less memory than reference types because they lack an ObjectHeader and a MethodTable.

4. **Guidelines for Struct Usage:**
    - Prefer classes in most scenarios.
    - Consider using structs when:
        - Struct size is 16 bytes or less (e.g., 4 integers).
        - Struct is short-lived.
        - Struct is immutable.
        - Struct won't be frequently boxed.

5. **Passing by Value:**
   Structs are passed by value. When passing a struct as a method parameter, the entire struct is copied. Note that copying can be expensive and potentially impact performance negatively.

In summary, while classes are generally favored, structs offer advantages in specific situations outlined by Microsoft's guidelines, taking into account size, lifespan, immutability, and boxing frequency.

### 4. Downsides of Finalizers in C#

Using finalizers in C# can be costly due to various reasons:

1. **Generation Promotion:**
   Classes with finalizers are automatically promoted to a higher generation by the garbage collector. Consequently, they cannot be collected in Gen 0, the fastest generation.

2. **Finalizer Queue and Thread Handling:**
   The finalizer is added to a Finalizer Queue, managed by a single dedicated thread. This setup can lead to issues if a finalizer takes a long time to run or if it throws an exception.

### 5. StackAlloc Keyword in C#

The `StackAlloc` keyword in C# facilitates rapid allocation and deallocation of unmanaged memory. It specifically supports primitives, structs, and arrays, but not classes.

### 6.Immutability of Strings and StringBuilder in C#

In C#, strings are immutable, meaning they cannot be changed. Any concatenation operation like `str1 = str1 + str2` results in the creation of a new object. To address the issue of frequent object allocations and enhance performance, the StringBuilder class was introduced.

Here's a summary of my recent blog post on StringBuilder performance:

- Regular concatenations are more efficient than StringBuilder for a small number of concatenations. StringBuilder becomes more efficient with over 10-15 concatenations, depending on string sizes.
- Optimizing StringBuilder is possible by setting its initial capacity.
- Reusing the same StringBuilder instance can offer optimization benefits, particularly in scenarios with frequent usage like logging.

### 7.String Interning

Approximately 60% of the human body is water, and interestingly, about 70% of a .NET application is comprised of strings. This underscores the significance of optimizing strings for effective memory management.

The .NET runtime features a concealed optimization known as String Interning. For literal strings with the same value, it allocates just one object reference. For instance:

```csharp
string a = "Table";
string b = "Table";
```
Despite the appearance of allocating two different objects for `a` and `b`, the CLR optimizes and assigns just one object reference, leading to two positive outcomes:

#### Memory Saving:

Only one object is utilized, resulting in significant memory savings.

#### Efficient String Comparison:

String comparisons become more cost-effective. Reference equality is checked first, and as both `a` and `b` reference the same object, the comparison returns true without inspecting the string contents.

However, it's crucial to note that this optimization is exclusive to string literals (e.g., `string myString = "Something"`) and isn't applied to strings calculated at runtime. String interning is intentionally avoided for runtime-calculated strings due to its expense. When interning a new string, the runtime must search for an identical string in memory to find a match, which is a costly operation.

While the runtime automatically handles string interning for literals, you can manually perform string interning using the `string.Intern(string)` method. Additionally, you can check if a string is already interned with `string.IsInterned(string)`. However, this approach is applicable in very specific cases for optimization.

