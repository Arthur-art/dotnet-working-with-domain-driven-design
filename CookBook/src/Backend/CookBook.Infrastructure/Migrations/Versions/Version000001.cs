using FluentMigrator;

namespace CookBook.Infrastructure.Migrations.Versions;

[Migration((long)EnumVersions.CreateTableUser, "Create User Table")]
public class Version000001 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {

       var table = BaseVersion.DefaultInsertTable(Create.Table("User"));

        table
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable()
            .WithColumn("Phone").AsString(20).NotNullable();
    }
}
