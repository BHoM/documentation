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
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;
using BH.oM.Base;
using BH.oM.Reflection;
using BH.Engine.Base;

namespace BH.Engine.External.SoftwareName // Replace SoftwareName with the name of your Toolkit software.
{
    public static partial class Modify
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/
		// All public engine methods are reflected into the UIs.
		// Modify methods must return the same object type that is passed as the first argument.
		// To ensure immutability in the UI, the object being modified must be cloned, so modification by reference is avoided.

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
		
		/***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/
		// Include here any private method that the public one might need to reference.
		// Private methods are not reflected in the UIs.
		
		
		/***************************************************/
    }
}
