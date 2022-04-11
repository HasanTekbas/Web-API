using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.Models.Dto;
using WebApi.Models.Entity;
using WebApi.Query.Dto;
using WebApi.Query.Entity;

namespace WebApi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;
        public TestController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        [HttpGet("api/GetKategoriler")]
        public async Task<IEnumerable<KategoriEntity>> GetKategoriAsync()
        {
            return await new DapperRepository(_dbConnection).QueryAsync<KategoriEntity>(
                KategoriQuery.GetKategoriSql);
        }

        [HttpGet("api/GetUrunler/{kategoriId}")]
        public async Task<IEnumerable<UrunEntity>> GetUrunAsync(int kategoriId)
        {
            return await new DapperRepository(_dbConnection).QueryAsync<UrunEntity>
                (UrunQuery.GetUrunSql,
                new
                {
                    kategoriId = kategoriId
                });
        }

        [HttpGet("api/GetKategoriUrunByKategoriId/{kategoriId}")]
        public async Task<IEnumerable<KategoriUrunDto>> GetKategoriUrunByKategoriIdAsync(int kategoriId)
        {
            return await new DapperRepository(_dbConnection).QueryAsync<KategoriUrunDto>(
                KategoriUrunQuery.GetKategoriUrunByKategoriIdSql,
                new
                {
                    kategoriId = kategoriId
                });
        }
        [HttpGet("api/GetKategoriUrunByUrunId/{urunId}")]
        public async Task<IEnumerable<KategoriUrunDto>> GetKategoriUrunByUrunIdAsync(int urunId)
        {
            return await new DapperRepository(_dbConnection).QueryAsync<KategoriUrunDto>(
                KategoriUrunQuery.GetKategoriUrunByUrunIdSql,
                new
                {
                    urunId = urunId
                });
        }





        [HttpPost("AddKategori")]
        public async Task<int> AddKategori(KategoriEntity kategori)
        { 
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(KategoriQuery.InsertKategoriSql,kategori);
        }
        
        [HttpPost("UpdateKategori")]
        public async Task<int> UpdateKategori(KategoriEntity kategori)
        {
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(KategoriQuery.UpdateKategoriSql, kategori);
        }

        [HttpPost("DeleteKategori")]
        public async Task<int> DeleteKategori(int Id)
        {
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(KategoriQuery.DeleteKategoriSql, new { Id = Id });
        }




        [HttpPost("AddUrun")]
        public async Task<int> AddUrun(UrunEntity urun)
        {
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(UrunQuery.InsertUrunSql, urun);
        }

        [HttpPost("UpdateUrun")]
        public async Task<int> UpdateUrun(UrunEntity urun)
        {
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(UrunQuery.UpdateUrunSql, urun);
        }

        [HttpPost("DeleteUrun")]
        public async Task<int> DeleteUrun(int Id)
        {
            return await new DapperRepository(_dbConnection)
                .ExecuteAsync(UrunQuery.DeleteUrunSql, new { Id=Id});
        }

        [HttpGet("api/GetMultibleOrnek")]
        public async Task<(IEnumerable<KategoriUrunDto> kategoriUrunDtos, IEnumerable<KategoriEntity> kategoriler)>
            GetMultibleOrnek(int kategoriId = -1)
        {
            var result = await new DapperRepository(_dbConnection).GetMultipleAsync(KategoriUrunQuery.GetUrunDtoVeKategoriListesiSql,
                new
                {
                    kategoriId = kategoriId
                });
            var kategoriUrunDto = await result.ReadAsync<KategoriUrunDto>();
            var kategoriler = await result.ReadAsync<KategoriEntity>();
            return (kategoriUrunDto, kategoriler);
        }
        [HttpPost("AddKategoriV2")]
        public async Task<KategoriEntity> AddKategoriV2(KategoriEntity kategori)
        {
            return await new DapperRepository(_dbConnection).QueryFirstOrDefaultAsync<KategoriEntity>
                (KategoriQuery.InsertKategoriSqlV2, kategori);

        }
        [HttpPost("UpdateKategoriV2")]
        public async Task<KategoriEntity> UpdateKategoriV2(KategoriEntity kategori)
        {
            return await new DapperRepository(_dbConnection).QueryFirstOrDefaultAsync<KategoriEntity>
(KategoriQuery.UpdateKategoriSqlV2, kategori);
        }
    }
}
