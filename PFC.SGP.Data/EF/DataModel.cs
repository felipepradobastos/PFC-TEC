namespace PFC.SGP.Data.EF
{
    public class DataModel
    {
        private static PFCSGPDataContext _context;
        public static PFCSGPDataContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new PFCSGPDataContext();
                    return _context;
                }
                return _context;
            }
        }
    }
}
