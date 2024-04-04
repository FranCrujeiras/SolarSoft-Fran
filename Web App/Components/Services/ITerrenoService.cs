using Microsoft.AspNetCore.Mvc;

namespace WebAppBlazor.Components.Services
{
    public interface ITerrenoService
    {
        #region GETs
        Task<Models.Terreno[]> GetTerrenos();
        Task<Models.Terreno> GetTerreno(int Id);
        #endregion
        //#region POSTs
        //Task<ActionResult<Models.Terreno>> PostTerreno(Models.Terreno terreno);
        //#endregion
        #region PUTs
        Task<bool> PutLatitud(int Id, double Latitud);
        Task<bool> PutLongitud(int Id, double Longitud);
        Task<bool> PutModeloPanel(int Id, string ModeloPanel);
        Task<bool> PutAnchoTerreno(int Id, double AnchoTerreno);
        Task<bool> PutLargoTerreno(int Id, double LargoTerreno);
        Task<bool> PutPotenciaPanel(int Id, int PotenciaPanel);
        Task<bool> PutAnguloEstructura(int Id, int AnguloEstructura);
        Task<bool> PutVoltajePanel(int Id, double VoltajePanel);
        #endregion
        #region DELETE
        Task<bool> DeletePanel(int Id);
        #endregion





    }
}
