using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class QRLoginTransactionDao : DaoBaseClass<QRLoginTransaction, QRLoginTransactionBusinessModel>, IQRLoginTransactionDao  
    {  
        public QRLoginTransactionDao(DbContext context) : base(context, "QRLoginTransactionId")  
        {  
        }  
    }  
}  
