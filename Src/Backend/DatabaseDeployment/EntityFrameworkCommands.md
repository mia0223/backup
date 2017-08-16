## To add a migration script:
Set TEK.SeatPlan.ResourceAccess as the startup project
Open the Package Manger Concole in VS
select TEK.SeatPlan.ResourceAccess in the default project dropdownlist
run the following command:

```
Add-Migration -Name "MigrationName" -Context TEK.SeatPlan.ResourceAccess.DataContext
```


# To update the database to the latest migration:
Set TEK.SeatPlan.ResourceAccess as the startup project
Open the Package Manger Concole in VS
select TEK.SeatPlan.ResourceAccess in the default project dropdownlist

```
Update-Database -Context TEK.SeatPlan.ResourceAccess.DataContext
```
