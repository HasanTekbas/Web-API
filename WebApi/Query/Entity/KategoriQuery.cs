namespace WebApi.Query.Entity
{
    public class KategoriQuery
    {
        public const string GetKategoriSql = 
            @"SELECT * FROM Kategori";

        public const string InsertKategoriSql = @"INSERT INTO [dbo].[Kategori]
           ([Adi])
     VALUES
           (@Adi)";

        public const string UpdateKategoriSql = @"UPDATE [dbo].[Kategori]
                                        SET [Adi] = @Adi
                                        WHERE Id=@Id";

        public const string DeleteKategoriSql = @"DELETE FROM [dbo].[Kategori]
                                        WHERE Id=@Id";

        public const string InsertKategoriSqlV2 = @"INSERT INTO [dbo].[Kategori]([Adi])
            OUTPUT INSERTED.*
            VALUES
            (@Adi)";
        public const string UpdateKategoriSqlV2 = @"UPDATE [dbo].[Kategori]
            SET [Adi] = @Adi            
            OUTPUT INSERTED.*
            WHERE Id=@Id";
    }
}
