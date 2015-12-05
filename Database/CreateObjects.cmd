@ECHO OFF

SET SQLCMD="C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE"
SET SERVER=(local)\SQLExpress
SET DATABASE=Authorization

%SQLCMD% -S %SERVER% -d %DATABASE% -i Constraints\DropForeignKeys.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\LoginSession.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\User.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\UserRole.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\Role.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\RoleAction.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Tables\Action.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i "Stored Procedures\LoadRoles.sql"
%SQLCMD% -S %SERVER% -d %DATABASE% -i "Stored Procedures\LoadActions.sql"
%SQLCMD% -S %SERVER% -d %DATABASE% -i Constraints\CreateForeignKeys.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Data\Actions.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Data\Roles.sql
%SQLCMD% -S %SERVER% -d %DATABASE% -i Data\Admins.sql
