/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/


namespace TUVienna.CS_CUP
{

	using System.Collections;

	/** This class represents the complete "reduce-goto" table of the parser.
	 *  It has one row for each state in the parse machines, and a column for
	 *  each terminal symbol.  Each entry contains a state number to shift to
	 *  as the last step of a reduce. 
	 *
	 * @see     java_cup.parse_reduce_row
	 * @version last updated: 11/25/95
	 * @author  Scott Hudson
     * translated to C# 08.09.2003 by Samuel Imriska
	 */
	public class parse_reduce_table 
	{
 
		/*-----------------------------------------------------------*/
		/*--- Constructor(s) ----------------------------------------*/
		/*-----------------------------------------------------------*/

		/** Simple constructor.  Note: all terminals, non-terminals, and productions 
		 *  must already have been entered, and the viable prefix recognizer should
		 *  have been constructed before this is called.
		 */
		public parse_reduce_table()
		{
			/* determine how many states we are working with */
			_num_states = lalr_state.number();

			/* allocate the array and fill it in with empty rows */
			under_state = new parse_reduce_row[_num_states];
			for (int i=0; i<_num_states; i++)
				under_state[i] = new parse_reduce_row();
		}

   
		/*-----------------------------------------------------------*/
		/*--- (Access to) Instance Variables ------------------------*/
		/*-----------------------------------------------------------*/

		/** How many rows/states in the machine/table. */
		protected int _num_states;

		/** How many rows/states in the machine/table. */
		public int num_states() {return _num_states;}

		/*. . . . . . . . . . . . . . . . . . . . . . . . . . . . . .*/

		/** Actual array of rows, one per state */
		public  parse_reduce_row[] under_state;
 
		/*-----------------------------------------------------------*/
		/*--- General Methods ---------------------------------------*/
		/*-----------------------------------------------------------*/

		/** Convert to a string. */
		public override string ToString()
		{
			string result;
			lalr_state goto_st;
			int cnt;

			result = "-------- REDUCE_TABLE --------\n";
			for (int row = 0; row < num_states(); row++)
			{
				result += "From state #" + row + "\n";
				cnt = 0;
				for (int col = 0; col < parse_action_row.size(); col++)
				{
					/* pull out the table entry */
					goto_st = under_state[row].under_non_term[col];

					/* if it has action in it, print it */
					if (goto_st != null)
					{
						result += " [non term " + col + "->"; 
						result += "state " + goto_st.index() + "]";

						/* end the line after the 3rd one */
						cnt++;
						if (cnt == 3)
						{
							result += "\n";
							cnt = 0;
						}
					}
				}
				/* finish the line if we haven't just done that */
				if (cnt != 0) result += "\n";
			}
			result += "-----------------------------";

			return result;
		}

		/*-----------------------------------------------------------*/

	}
}
