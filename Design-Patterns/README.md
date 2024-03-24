# Design-Patterns
Based on the provided descriptions, it seems like you've done a good job adhering to various programming principles in your code. Let's summarize how each principle is applied in your code:

### Money.cs
1. **DRY (Don't Repeat Yourself):** You've mentioned the use of the `isCorrectMoney` method to check the correctness of money units in multiple places, which avoids code duplication.
   
2. **SOLID Principles:**
   - **Single Responsibility Principle:** The `Money` class is responsible only for representing money and performing operations on them.
   - **Open/Closed Principle:** It can be extended to add new operations by creating new methods.
   - **KISS (Keep It Simple, Stupid):** The `Money` class has a simple structure with clear methods for basic operations on money.
   - **YAGNI (You Aren't Gonna Need It):** Implements only the necessary functionality for representing and operating on money.
   - **Composition Over Inheritance:** Utilizes composition rather than inheritance; the `Money` class doesn't inherit from any other class.
   - **Program to Interfaces not Implementations:** While interfaces are not explicitly mentioned in the code, it could be implemented by using interfaces for different money operations.
   - **Fail Fast:** The methods of the `Money` class check the correctness of data and raise exceptions in case of incorrect input or operations.

### Reporting.cs
1. **Single Responsibility Principle:** The `Reporting` class is responsible for collecting and sending event messages in the system, such as adding or removing items or checking the availability of products in stock.
   
2. **Open/Closed Principle:** It can be extended to add new types of messages without modifying its own code. It receives dependencies through its constructor, making it flexible to use with any message processing functions.
   
3. **Liskov Substitution Principle:** The `Reporting` class can be used anywhere an object implementing the `IReporting` interface is needed, without changing how it's used.
   
4. **Interface Segregation Principle:** The `IReporting` interface contains only methods related to reporting functionality, allowing classes to implement this interface without carrying unnecessary functionality.
   
5. **Dependency Inversion Principle:** The `Reporting` class receives its dependency (in the form of a delegate `Action<string>`) through its constructor, allowing it to be used with any message processing functions without being tied to specific implementations.

### Warehouse.cs
1. **Single Responsibility Principle:** The `Warehouse` class is responsible for storing and managing items in the warehouse. It's only responsible for performing operations on items, while the repository work is delegated to another class.
   
2. **Open/Closed Principle:** It can be extended for adding new functionalities by using the repository as an abstraction. Changes in the repository don't require modifications in the warehouse code.
   
3. **Dependency Inversion Principle:** The `Warehouse` class receives its dependency from the repository through its `IWarehouseRepository` interface. This allows easy replacement of the specific repository implementation without changes to the warehouse code.

### WarehouseRepository.cs
1. **Single Responsibility Principle:** The `WarehouseRepository` class is responsible for storing and managing items in the warehouse through interaction with the database. It's also responsible for sending event messages in the system, such as adding or removing items, using the `IReporting` interface.
   
2. **Open/Closed Principle:** It can be extended to interact with different data sources (e.g., databases of different types) by implementing another interface that extends `IWarehouseRepository`.
   
3. **Dependency Inversion Principle:** The `WarehouseRepository` class receives dependencies from the database context and the event reporting object through its constructor. This allows easy replacement of the database context and reporting object without changes to the `WarehouseRepository` code.

Overall, your code demonstrates a good understanding and application of SOLID principles, as well as other programming principles like DRY, KISS, and YAGNI. Keep up the good work!
