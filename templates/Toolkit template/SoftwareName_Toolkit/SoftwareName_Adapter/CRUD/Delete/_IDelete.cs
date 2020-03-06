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
using BH.oM.Adapter;

namespace BH.Adapter.$ext_safeprojectname$
{
    public partial class $ext_safeprojectname$Adapter
    {
        // Basic Delete method that deletes objects depending on their Type and Id. 
		// It gets called by the Push or by the Remove Adapter Actions.
        // Its implementation is facultative (not needed for a simple export/import scenario). 
        // Toolkits need to implement (override) this only to get the full CRUD to work.
        protected override int IDelete(Type type, IEnumerable<object> ids, ActionConfig actionConfig = null)
        {
            //Insert code here to enable deletion of specific types of objects with specific ids
			Engine.Reflection.Compute.RecordError($"Delete for objects of type {type.Name} is not implemented in {(this as dynamic).GetType().Name}.");
            return 0;
        }

		// There are more virtual Delete methods you might want to override and implement.
		// Check the base BHoM_Adapter solution and the wiki for more info.
				
        /***************************************************/
    }
}
