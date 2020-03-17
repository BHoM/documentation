/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.Base;
using BH.oM.Adapter;

namespace BH.Adapter.$ext_safeprojectname$
{
    public partial class $ext_safeprojectname$Adapter
    {
    // NOTE: CRUD folder methods
    // All methods in the CRUD folder are used as "back-end" methods by the Adapter itself.
	// They are automatically invoked by the Adapter Actions (Push, Pull, etc.).
	// Specifically, the Create is primarily called by the Push (in the context of the CRUD method, and also by other methods that require it: Update, UpdateProperty).
	// See the wiki for more information.

        // The Create should only contain the logic that generates the objects in the external software.
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
			bool success = true;
			
			// Preferrably, different Create logic for different object types should go in separate methods.
            // We achieve this by using the ICreate method to only dynamically dispatching to *type-specific Create implementations*
            // In other words:
			foreach (T obj in objects)
            {
				success &= Create(obj as dynamic);
            } 

			// Then place the specific Create methods below this method or, better, in separate file for each object type.
            return success;  
        }
		
		// Write your type-specific implementations of Create like:
        // protected bool Create(IEnumerable<BH.oM.Structure.Elements.Node> node) //`Node` is just an example BHoM Type.
        // { 
        //      // Code to do the Create of `Node`s, including:
        //      //  - calling `Convert` methods from the BHoM type to the external object model
		//      //    (Convert methods should be defined in the specific `Convert` folder);
		//      //  - any API call that do the actual export to the external software.
		//    return true; // if successfull
        // }

        /***************************************************/
		
		// Fallback case. If no specific Create is found, here we should handle what happens then.
        protected bool Create(IBHoMObject obj)
        { 
		   BH.Engine.Reflection.Compute.RecordError("No specific Create method found for {obj.GetType().Name}.");
		   return false;
        }
    }
}
