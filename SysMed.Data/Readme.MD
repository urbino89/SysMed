# Package Manager Console scripts for Migrations
# Initial Migration:
add-migration CreateSysMedDb -Verbose
# Script Migration:
Script-Migration 
Script-Migration -From <PreviousMigration> -To <LastMigration>
