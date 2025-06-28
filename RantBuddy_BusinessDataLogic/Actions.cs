using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RantBuddyBusinessDataLogic
{
    public enum Actions
    // enum to store the actions
    {
        CreateOrAddEntry = 1,
        RetrieveOrViewEntries,
        UpdateEntry,
        DeleteEntry,
        Search,
        Exit
    }
}