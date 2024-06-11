# WorkingSoftware-2024
Workshop "From EventStorming to Event Store"

# Scenario
1. Create BeerAvailability in Warehouse module
   1. After the **CreateBeerAvailability** has been processed an EventHandler updates the ReadModel in Warehouse, and a second EventHandler Raise an IntegrationEvent **BeerAvailabilityCommunicated** for the other modules
2. The **BeerAvailabilityCommunicated** IntegrationEvent is subscribed by Sales.Acl (AntiCorruption Layer). This module transforms the IntegrationEvent in Command to update the local ReadModel
   1. The responsibility for the aggregate "BeerAvailability" lies with Warehouse. Sales keeps a possibly substantial copy so as not to be dependent on Warehouse.
3. When we have beer available, we can create a SalesOrder. The command **CreateSalesOrder** creates a sales order in Sales. The aggregate **SalesOrder** raises the DomainEvent **SalesOrderCreated**.
   1. This DomainEvent has two EventHandlers. The first one to update the ReadModel. The second one to publish an IntegrationEvent for Warehouse to update the BeerAvailability after a new order was received.

# What is ModularArchitecture
The idea behind this architecture style is simple:  
> - Low Coupling: Each module should be independent of other modules in the system  
> - High Cohesion: Components of the module are all related thus making it easier to understand what module does as a self-contained subsystem (SRP)  

# Fitness Functions
Are special tests that ensure that the architecture, defined at the beginning of the project, remains valid.  
In this solution we used two different libraries  
> - NetArchtest is a fluent API for .Net Standard that can enforce architectural rules in unit tests. It's inspired by the ArchUnit library for java  

# Run Solution
> - docker build -t brewup .  
> - docker run --rm -p 5000:8080 brewup