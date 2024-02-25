using FluentMigrator;

namespace CookBook.Infrastructure.Migrations.Versions;

[Migration((long)EnumVersions.CreateTabCookBook, "Create Table CookBook and Ingredients")]
public class Version000002 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        CreateCookBookTable();
        CreateIngredientsTable();
    }

    public void CreateCookBookTable()
    {
        var table = BaseVersion.DefaultInsertTable(Create.Table("CookBook"));

        table
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("Category").AsInt16().NotNullable()
            .WithColumn("MethodPreparation").AsString(5000).NotNullable();
    }

    public void CreateIngredientsTable()
    {
        var table = BaseVersion.DefaultInsertTable(Create.Table("Ingredients"));

        table
            .WithColumn("Product").AsString(100).NotNullable()
            .WithColumn("Quantity").AsString(100).NotNullable()
            .WithColumn("CookBookId").AsInt64().NotNullable().ForeignKey("FK_Ingredients_CookBook_Id", "CookBook", "Id");
    }
}
