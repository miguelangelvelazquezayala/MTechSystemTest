# MTechSystemTest

## Create a solution that can:

- Persist Employees to a data store
- Validate uniqueness of an employee (uniqueness is defined by RFC)
- Validate RFC Format and length
- Retrieve Employees sorted by birth date and filtered optionally by name

## Considerations:
- UI can be any Microsoft presentation technology (Web API, ASP.NET MVC, etc.)
- The components used should be able to be consumed by an alternate presentation layer
- Don't focus on aesthetics
- Any 3rd party libraries can be used
- Any code that you've built for previous applications can be used

```
public class Employee

{

                public int ID { get; set}

               

                public string Name { get; set;}

               

                public string LastName { get; set;}

 

               public string RFC { get; set;}

               

                public DateTime BornDate { get; set; }    

               

                public EmployeeStatus Status { get; set; }

}

```

```
public enum EmployeeStatus

{

                NotSet,

                Active,

                Inactive,             

}

```