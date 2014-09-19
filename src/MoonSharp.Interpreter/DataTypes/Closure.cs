﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter.Execution;

namespace MoonSharp.Interpreter
{
	/// <summary>
	/// A class representing a script function
	/// </summary>
	public class Closure : IScriptPrivateResource
	{
		/// <summary>
		/// Gets the entry point location in bytecode .
		/// </summary>
		public int EntryPointByteCodeLocation { get; private set; }

		/// <summary>
		/// Gets the ClosureContext for upvalues of this function
		/// </summary>
		public ClosureContext ClosureContext { get; private set; }

		/// <summary>
		/// Gets the script owning this function
		/// </summary>
		public Script OwnerScript { get; private set; }


		/// <summary>
		/// Shortcut for an empty closure
		/// </summary>
		private static ClosureContext emptyClosure = new ClosureContext();


		/// <summary>
		/// Initializes a new instance of the <see cref="Closure"/> class.
		/// </summary>
		/// <param name="script">The script.</param>
		/// <param name="idx">The index.</param>
		/// <param name="symbols">The symbols.</param>
		/// <param name="resolvedLocals">The resolved locals.</param>
		internal Closure(Script script, int idx, SymbolRef[] symbols, IEnumerable<DynValue> resolvedLocals)
		{
			OwnerScript = script;

			EntryPointByteCodeLocation = idx;

			if (symbols.Length > 0)
				ClosureContext = new ClosureContext(symbols, resolvedLocals);
			else
				ClosureContext = emptyClosure;
		}

	}
}
