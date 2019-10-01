/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Adapter.$ext_safeprojectname$
{
    public partial class $ext_safeprojectname$
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        // Method that returns the next free index for a specific object type as 'object'. 
        // 'object' is required as ID is software specific (could be int, string, Guid or anything else).
        // NextId is called in the base Adapter Push method, just before the call to Create();
        // it follows that at the point of index assignment, the objects have not yet been created in the target software. 
        // This is to ensure that the object exported in the software will have the the ID that we decided here.
        protected override object NextId(Type objectType, bool refresh = false)
        {
            //Change from object to what the specific software is using
            object index;

            // This 'if' is to grab the first free index for the first object being created and after that increment.
            if (!refresh && m_indexDict.TryGetValue(objectType, out index))
            {
                // If it is possible to infer the next index based on the previous one 
                // (for example index++ for an int based index system), then do it here
                // Example int based:
                // index++
            }
            else
            {
                index = 0; //Insert code to get the next index of the specific type
            }

            m_indexDict[objectType] = index;
            return index;
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        // Change from object to the index type used by the specific software
        private Dictionary<Type, object> m_indexDict = new Dictionary<Type, object>();


        /***************************************************/
    }
}
