using FluentMigrator.Builders.Create.Table;

namespace CookBook.Infrastructure.Migrations;

public static class BaseVersion
{
    public static ICreateTableColumnOptionOrWithColumnSyntax DefaultInsertTable(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        return table
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("CreateDate").AsDateTime().NotNullable();
    }
}
