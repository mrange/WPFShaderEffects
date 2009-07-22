/* ****************************************************************************
 *
 * Copyright (c) Mårten Rånge.
 *
 * This source code is subject to terms and conditions of the Microsoft Public License. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Microsoft Public License, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Microsoft Public License.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/

using System;

namespace WpfShaderEffects.DirectX.Interop
{
   struct D3DXCONSTANT_DESC
   {
      public IntPtr Name; // Lft name
      public D3DXREGISTER_SET RegisterSet; // Register set
      public uint RegisterIndex; // Register index
      public uint RegisterCount; // Number of registers occupied
      public D3DXPARAMETER_CLASS Class; // Class
      public D3DXPARAMETER_TYPE Type; // Component type
      public uint Rows; // Number of rows
      public uint Columns; // Number of columns
      public uint Elements; // Number of array elements
      public uint StructMembers; // Number of structure member sub-parameters
      public uint Bytes; // Data size, in bytes
      public IntPtr DefaultValue; // Pointer to default value
   }
}