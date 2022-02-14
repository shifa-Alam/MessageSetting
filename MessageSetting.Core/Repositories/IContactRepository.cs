using MessageSetting.Core.Entities;
using MessageSetting.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        //custom operations here
        public void UpdateRangeAsync(IEnumerable<Contact> entities);

        public void UpdateParentWithChild(Contact entity);

        public IEnumerable<Contact> GetAllIncludeChild();
    }
}
