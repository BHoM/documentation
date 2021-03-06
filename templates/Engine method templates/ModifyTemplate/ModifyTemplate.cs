﻿/*
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
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using BH.oM.Base;
using BH.oM.Reflection;
using BH.Engine.Base;

namespace $rootnamespace$ //Modify is a partial class. Remove any reference to Modify from the namespace
{
    public static partial class Modify
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("")]
		[Input("","")]
        [Output("", "")]
        public static SomeObjectType $safeitemname$(SomeObjectType obj)
        {
			// // - First thing, clone the object to ensure immutability.
			// // - You can do a light Shallow clone if the object type is BHoMObject and a shallow clone is enough for your case:
			// SomeObjectType objClone = obj.GetShallowClone() as SomeObjectType;
			
			// // - Otherwise, BH.Engine.Base offers an efficient DeepClone method.
			// SomeObjectType objClone = BH.Engine.Base.Query.DeepClone(obj);
			
			// If you need to log Error or Warnings and expose them to the user, use:
			// BH.Engine.Reflection.Compute.RecordError("Error text") or RecordWarning
			
			throw new NotImplementedException();
        }

        /***************************************************/

    }
}
