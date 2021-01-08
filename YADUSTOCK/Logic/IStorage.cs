using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Interface for the storage layer
    /// </summary>
    public interface IStorage
    {

        /// <summary>
        /// Load the Memory
        /// </summary>
        /// <returns>the Memory loaded (or a new notebook)</returns>
        Memory Load();
        /// <summary>
        /// Save the Memory
        /// </summary>
        /// <param name="m">the Memory to save</param>
        void Save(Memory m);
    }
}
