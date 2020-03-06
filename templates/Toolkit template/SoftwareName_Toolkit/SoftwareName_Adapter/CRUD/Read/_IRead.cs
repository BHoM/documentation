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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Common.Materials;

namespace BH.Adapter.$ext_safeprojectname$
{
    public partial class $ext_safeprojectname$Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        // This method gets called when appropriate by the Pull method contained in the base Adapter class.
        // It gets called once per each Type.
        protected override IEnumerable<IBHoMObject> Read(Type type, IList ids, ActionConfig actionConfig = null)
        {			
            // Preferrably, different Create logic for different object types should go in separate methods.
            // We achieve this by using the ICreate method to only dynamically dispatching to *type-specific Create implementations*
            // In other words:
            // if (type == typeof(SomeType1))
            //     return ReadSomeType1(ids as dynamic);
            // else if (type == typeof(SomeType2))
            //     return ReadSomeType2(ids as dynamic);
            // else if (type == typeof(SomeType3))
            //     return ReadSomeType3(ids as dynamic);

            return new List<IBHoMObject>();
        }

        /***************************************************/

    }
}
