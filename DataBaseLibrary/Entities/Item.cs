using System;

namespace DataBaseLibrary.Entities
{
    public class Item
    {
        #region Propperties

        public Guid Id { get; set; }
        
        public string CourceName { get; set; }
        
        public string AdditionalInformation { get; set; }

        public string Audience { get; set; }

        public Guid EntityId { get; set; }

        public int NumberOfDay { get; set; }

        public int Order { get; set; }
        
        #endregion
    }
}
