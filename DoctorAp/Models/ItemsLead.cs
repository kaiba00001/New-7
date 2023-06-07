namespace DoctorAp.Models
{
    public class ItemsLead
    {
     
            public int Id { get; set; }
            public string Item { get; set; }
            public int Quantity { get; set; }
            public decimal CostPerItem { get; set; }
            public decimal TotalAmount => Quantity * CostPerItem; // Add TotalAmount property
                                                                 
       

    }
}
