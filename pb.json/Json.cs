/*
 * 
 *  Json.cs
 *  Nicholas Wilson
 *  1/30/2018
 *  
 *  Classes for serializing and deserializing Json objects in C#
 * 
 * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace pb.json
{

    /// <summary>
    /// An object for serializing and deserializing Json objects
    /// </summary>
    public class JSONObject
    {

        /// <summary>
        /// The internal dictionary of the json objects
        /// </summary>
        private Dictionary<string, object> items = new Dictionary<string, object>();

        /// <summary>
        /// Empty constructor
        /// Initialize a blank Json object
        /// </summary>
        public JSONObject() { }

        /// <summary>
        /// Initialize a Json object with a Json string
        /// </summary>
        /// <param name="json">A Json string to populate this object</param>
        public JSONObject(string json)
        {
            Parse(json);
        }

        /// <summary>
        /// Get the object mapped by name or error is no such mapping exists
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name</returns>
        public Object Get(string name)
        {
            return items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a string
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a string</returns>
        public string GetString(string name)
        {
            return (string)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a boolean
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a boolean</returns>
        public bool GetBoolean(string name)
        {
            return (bool)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into an int
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into an int</returns>
        public int GetInt(string name)
        {
            return (int)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a double
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a double</returns>
        public double GetDouble(string name)
        {
            return (double)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a long
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a long</returns>
        public long GetLong(string name)
        {
            return (long)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a Json object
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a Json object</returns>
        public JSONObject GetJSONObject(string name)
        {
            return (JSONObject)items[name];
        }

        /// <summary>
        /// Get the object mapped by name if it exists and can be coereced into a Json array
        /// or throw an error otherwise
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>The object mapped by the name coerced into a Json array</returns>
        public JSONArray GetJSONArray(string name)
        {
            return (JSONArray)items[name];
        }

        /// <summary>
        /// Returns if a field with the name mapping exists in this object
        /// </summary>
        /// <param name="name">The name field for the mapping</param>
        /// <returns>If a field with the name mapping exists in this object</returns>
        public Boolean Has(string name)
        {
            return items.ContainsKey(name);
        }

        /// <summary>
        /// The list of key mapping fields for this Json object
        /// </summary>
        public List<string> Keys
        {
            get
            {
                return new List<string>(items.Keys);
            }
        }

        /// <summary>
        /// The list of values that have been mapped in this Json object
        /// </summary>
        public JSONArray Values
        {
            get
            {
                JSONArray ja = new JSONArray();
                foreach (object o in items.Values)
                {
                    ja.Put(o);
                }
                return ja;
            }
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, object value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, string value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, bool value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, int value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, double value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, long value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, JSONObject value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// Maps name to value, clobbering any existing name/value mapping with the same name
        /// </summary>
        /// <param name="name">The field name for the mapping</param>
        /// <param name="value">The value to be mapped to the field name</param>
        /// <returns>This json object with the mapping added</returns>
        public JSONObject Put(string name, JSONArray value)
        {
            items[name] = value;
            return this;
        }

        /// <summary>
        /// The number of name/value mappings in this object
        /// </summary>
        /// <returns>The number of name/value mappings in this object</returns>
        public int Length
        {
            get
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Removes an object from this Json object by its name and returns it
        /// </summary>
        /// <param name="name">The name of the object to remove</param>
        /// <returns>The object that was removed from this Json object</returns>
        public object Remove(string name)
        {
            object o = items[name];
            items.Remove(name);
            return o;
        }

        /// <summary>
        /// Serializes this Json object as a Json string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Serialize(this);
        }

        /// <summary>
        /// Private method for serializing a Json object to a Json string
        /// </summary>
        /// <param name="jo">The Json object to serialize</param>
        /// <returns>A Json string representing the Json object</returns>
        private string Serialize(JSONObject jo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            int i = 0;

            foreach (string name in jo.items.Keys)
            {
                sb.Append(StringifyValue(name)).Append(":");
                if (items[name] is JSONObject)
                {
                    sb.Append(items[name]);
                }
                else if (items[name] is JSONArray)
                {
                    sb.Append(items[name].ToString());
                }
                else
                {
                    sb.Append(StringifyValue(items[name]));
                }
                if (++i < items.Keys.Count) sb.Append(',');
            }

            sb.Append('}');
            return sb.ToString();
        }

        /// <summary>
        /// Private method for turning a Json field into a string for serialization
        /// </summary>
        /// <param name="o">The object to serialize</param>
        /// <returns>The serialized string of the object</returns>
        private string StringifyValue(object o)
        {
            if (o == null) return "null";
            if (o is string) return "\"" + ((string)o).Replace("\\", "\\\\").Replace("\t", "\\t")
                    .Replace("\b", "\\b").Replace("\f", "\\f").Replace("\n", "\\n")
                    .Replace("\r", "\\r").Replace("\"", "\\\"") + "\"";
            else return o.ToString().ToLower(); //To lower for booleans
        }

        /// <summary>
        /// Private method for parsing a Json string into a Json object
        /// </summary>
        /// <param name="json">The Json string to parse</param>
        private void Parse(string json)
        {
            this.items = ParseJSONObject(json).items;
        }

        /// <summary>
        /// Private method for parsing a Json string into a Json object
        /// </summary>
        /// <param name="json">The Json string to parse</param>
        /// <returns>A deserialized Json object</returns>
        private JSONObject ParseJSONObject(string json)
        {
            JSONObject jo = new JSONObject();

            int bracketCounter = 0;
            int curlyBracketCounter = 0;
            bool hasEnteredObject = false;

            bool inLiteral = false;
            bool inNestedJsonObject = false;
            bool inNestedArray = false;

            bool expectingName = true;
            string currentFieldName = null;

            bool buildingPrimitiveValue = false;

            bool escapingCharacter = false;

            StringBuilder buffer = new StringBuilder();

            //Loop through every character in the Json string
            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                if (inLiteral && !(!escapingCharacter && c == '"'))
                {
                    //Handle escape characters in string literals
                    if (inLiteral && c == '\\')
                    {
                        if (escapingCharacter)
                        {
                            escapingCharacter = false;
                            buffer.Append('\\');
                        }
                        else
                        {
                            escapingCharacter = true;
                        }
                    }
                    else if (c != '"')
                    {
                        //Look for the next character in an escape character if we are escaping
                        if (escapingCharacter)
                        {
                            if (c == 'b') buffer.Append('\b');
                            else if (c == 'f') buffer.Append('\f');
                            else if (c == 'n') buffer.Append('\n');
                            else if (c == 'r') buffer.Append('\r');
                            else if (c == 't') buffer.Append('\t');
                            else if (c == '"') buffer.Append('\"');
                            else
                            {
                                //We were escaping a character but this isn't a valid one
                                throw new MalformedJsonException();
                            }
                            escapingCharacter = false;
                        }
                        else
                        {
                            //Add to the buffer if inside a literal
                            buffer.Append(c);
                        }
                    }
                    else if (c == '"' && escapingCharacter && inLiteral)
                    {
                        buffer.Append('"'); escapingCharacter = false;
                    }
                }
                else if (inNestedJsonObject && c != '}' || inNestedArray && c != ']')
                {
                    //Add to the buffer if inside a nested Json object
                    buffer.Append(c);
                }
                else if (char.IsWhiteSpace(c))
                { //Whitespace characters
                    if (buildingPrimitiveValue && !inNestedJsonObject && !inNestedArray)
                    {
                        //This would mean we didn't enclose a literal and are looking for a value
                        //The buffer should be a value
                        jo.Put(currentFieldName, ParseValue(buffer.ToString()));
                        buffer.Length = 0;
                        expectingName = true;
                        buildingPrimitiveValue = false;
                    }
                }
                else if (c == '{')
                {
                    bracketCounter++;
                    if (bracketCounter == 1 && hasEnteredObject)
                    {
                        throw new MalformedJsonException();
                    }
                    hasEnteredObject = true;

                    if (bracketCounter > 1)
                    {
                        //This should only happen when expecting a value
                        if (expectingName)
                        {
                            throw new MalformedJsonException();
                        }
                        inNestedJsonObject = true;
                        buffer.Append(c);
                    }
                }
                else if (c == '}')
                {
                    bracketCounter--;
                    if (bracketCounter < 0)
                    {
                        throw new MalformedJsonException();
                    }
                    else if (bracketCounter == 1)
                    {
                        if (inNestedJsonObject)
                        {
                            //This should only happen when expecting a value
                            if (expectingName)
                            {
                                throw new MalformedJsonException();
                            }
                            inNestedJsonObject = false;
                            buffer.Append(c);

                            //Parse the inner object and add it 
                            jo.Put(currentFieldName, ParseJSONObject(buffer.ToString()));
                            buffer.Length = 0;

                            //We need a name now
                            expectingName = true;
                        }
                    }
                    else if (bracketCounter == 0)
                    {
                        if (!expectingName && buildingPrimitiveValue)
                        {
                            //We weren't in an object and a bracket appeared
                            //The object should be ending in this case and this is the final value
                            jo.Put(currentFieldName, ParseValue(buffer.ToString()));
                            buffer.Length = 0;
                            expectingName = true;
                            buildingPrimitiveValue = false;
                        }
                    }
                }
                else if (c == '[')
                {
                    if (!hasEnteredObject)
                    {
                        throw new MalformedJsonException();
                    }
                    curlyBracketCounter++;
                    if (curlyBracketCounter > 0)
                    {
                        inNestedArray = true;

                        //This should only happen when expecting a value
                        if (expectingName)
                        {
                            throw new MalformedJsonException();
                        }
                        inNestedArray = true;
                        buffer.Append(c);
                    }
                }
                else if (c == ']')
                {
                    curlyBracketCounter--;
                    if (curlyBracketCounter < 0)
                    {
                        throw new MalformedJsonException();
                    }
                    else if (curlyBracketCounter == 0)
                    {
                        //This should only happen when expecting a value
                        if (expectingName)
                        {
                            throw new MalformedJsonException();
                        }
                        inNestedArray = false;
                        buffer.Append(c);

                        //Parse the inner object and add it 
                        jo.Put(currentFieldName, new JSONArray(buffer.ToString()));
                        buffer.Length = 0;

                        //We need a name now
                        expectingName = true;
                    }
                }
                else if (c == '"')
                { //Here we either just started or ended a literal
                    inLiteral = !inLiteral;
                    //If we're looking for a name and we just exited a literal
                    if (!inLiteral) //If we just ended a literal...
                    {
                        if (expectingName)
                        { //We were looking for a name, store it
                            //Store the field name
                            currentFieldName = buffer.ToString(); buffer.Length = 0;
                            //Expecting value now
                            expectingName = !expectingName;
                        }
                        else
                        { //We were expecting a value so we must have a string literal
                            jo.Put(currentFieldName, buffer.ToString()); buffer.Length = 0;
                            //Next up is a name
                            expectingName = true;
                        }
                    }
                }
                else if (c == ':')
                {
                    //We should have already flipped the switch in the quote logic
                    //So we could probably just ignore this
                    if (expectingName) throw new MalformedJsonException();
                }
                else if (c == ',')
                {
                    if (!expectingName)
                    {
                        //This would mean we didn't enclose a literal and are looking for a value
                        //The buffer should be a value
                        jo.Put(currentFieldName, ParseValue(buffer.ToString()));
                        buffer.Length = 0;
                        expectingName = true;
                        buildingPrimitiveValue = false;
                    }
                }
                else
                {
                    //Only accept other characters if in an object and looking for a value
                    if (hasEnteredObject && !expectingName)
                    {
                        buffer.Append(c);
                        //We are creating a primitive type
                        buildingPrimitiveValue = true;
                    }
                    else
                    {
                        throw new MalformedJsonException();
                    }
                }
            }

            //parse complete
            return jo;
        }

        /// <summary>
        /// Private method for returning a field value from a Json mapping string
        /// </summary>
        /// <param name="s">The string to deserialize into a value</param>
        /// <returns>The deserialized value</returns>
        private object ParseValue(string s)
        {
            if (s == "") return null;
            if (s == null) return null;
            if (s == "true" || s == "false") return bool.Parse(s);
            if (Regex.IsMatch(s, @"^[0-9-]+$"))
            {
                try
                {
                    return int.Parse(s);
                }
                catch
                {
                    return long.Parse(s);
                }
            }
            if (Regex.IsMatch(s, @"^[0-9.-]+$"))
            {
                return double.Parse(s);
            }

            return null;
        }

    }

    /// <summary>
    /// A class representing a Json array
    /// </summary>
    public class JSONArray
    {

        /// <summary>
        /// Private list of the objects in this Json array
        /// </summary>
        List<object> items = new List<object>();

        /// <summary>
        /// Empty constructor
        /// Initializes a blank Json array
        /// </summary>
        public JSONArray() { }

        /// <summary>
        /// Initialize a Json array from a Json string
        /// </summary>
        /// <param name="json">A Json string representing a Json array</param>
        public JSONArray(string json)
        {
            Parse(json);
        }

        /// <summary>
        /// Returns the value at index if it exists
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists</returns>
        public Object Get(int index)
        {
            return items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a boolean
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into a boolean</returns>
        public bool GetBoolean(int index)
        {
            return (bool)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a double
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into a double</returns>
        public double GetDouble(int index)
        {
            return (double)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into an int
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into an int</returns>
        public int GetInt(int index)
        {
            return (int)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a Json array
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into
        /// a Json array</returns>
        public JSONArray GetJSONArray(int index)
        {
            return (JSONArray)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a Json object
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into
        /// an Json object</returns>
        public JSONObject GetJSONObject(int index)
        {
            return (JSONObject)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a long
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into a long</returns>
        public long GetLong(int index)
        {
            return (long)items[index];
        }

        /// <summary>
        /// Returns the value at index if it exists and can be coerced into a string
        /// </summary>
        /// <param name="index">The index of the object to get</param>
        /// <returns>The value at index if it exists and can be coerced into a string</returns>
        public string GetString(int index)
        {
            return (string)items[index];
        }

        public bool IsNull(int index)
        {
            return items[index] == null;
        }

        /// <summary>
        /// The number of values in this Json array
        /// </summary>
        public int Length
        {
            get
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(object o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(double o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(long o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(string o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(bool o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(JSONObject o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(JSONArray o)
        {
            items.Add(o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, object o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, int o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, double o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, long o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, string o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, bool o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, JSONObject o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Put a value into this Json array
        /// </summary>
        /// <param name="o">The value to add to this Json array</param>
        /// <returns>This Json array</returns>
        public JSONArray Put(int index, JSONArray o)
        {
            items.Insert(index, o);
            return this;
        }

        /// <summary>
        /// Remove the object at the given index and returns it
        /// </summary>
        /// <param name="index">The index to remove the object</param>
        /// <returns>The removed object</returns>
        public object Remove(int index)
        {
            object o = items[index];
            items.RemoveAt(index);
            return o;
        }

        /// <summary>
        /// Serialize this Json array into a Json string and return it
        /// </summary>
        /// <returns>This Json array as a Json string</returns>
        public override string ToString()
        {
            return Serialize(this);
        }

        /// <summary>
        /// A private method for serializing a Json array into a string
        /// </summary>
        /// <param name="ja">A Json array to serialize</param>
        /// <returns>A Json string of the given Json array serialized</returns>
        private string Serialize(JSONArray ja)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');

            int i = 0;
            foreach (object o in ja.items)
            {
                if (o is JSONObject)
                {
                    sb.Append(o.ToString());
                }
                else if (o is JSONArray)
                {
                    sb.Append(o.ToString());
                }
                else
                {
                    sb.Append(StringifyValue(o));
                }
                if (++i < items.Count) sb.Append(',');
            }

            sb.Append(']');
            return sb.ToString();
        }

        /// <summary>
        /// Private method to convert a field into a serialized string for Json
        /// </summary>
        /// <param name="o">The object to serialize</param>
        /// <returns>The object serialized into a Json field string</returns>
        private string StringifyValue(object o)
        {
            if (o == null) return "null";
            if (o is string) return "\"" + ((string)o).Replace("\\", "\\\\")
                    .Replace("\t", "\\t").Replace("\b", "\\b")
                    .Replace("\f", "\\f").Replace("\n", "\\n")
                    .Replace("\r", "\\r").Replace("\"", "\\\"") + "\"";
            else return o.ToString().ToLower(); //To lower for booleans
        }

        /// <summary>
        /// Private method for parsing a Json string into a Json array
        /// </summary>
        /// <param name="json">The Json string to parse into a Json array</param>
        private void Parse(string json)
        {
            this.items = ParseJSONArray(json).items;
        }

        /// <summary>
        /// Private method for parsing a Json string into a Json array
        /// </summary>
        /// <param name="json">The Json string to parse into a Json array</param>
        /// <returns>The parsed Json array after deserializing the Json string</returns>
        private JSONArray ParseJSONArray(string json)
        {
            JSONArray jo = new JSONArray();

            int squareBracketCounter = 0;
            int curlyBracketCounter = 0;
            bool hasEnteredArray = false;

            bool inLiteral = false;
            bool inNestedJsonObject = false;

            bool escapingCharacter = false;

            bool buildingPrimitiveValue = false;
            bool expectingValue = false;

            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                if (inLiteral && !(!escapingCharacter && c == '"'))
                {
                    //Handle escape characters in string literals
                    if (inLiteral && c == '\\')
                    {
                        if (escapingCharacter)
                        {
                            escapingCharacter = false;
                            buffer.Append('\\');
                        }
                        else
                        {
                            escapingCharacter = true;
                        }
                    }
                    else if (c != '"')
                    {
                        //Look for the next character in an escape character if we are escaping
                        if (escapingCharacter)
                        {
                            if (c == 'b') buffer.Append('\b');
                            else if (c == 'f') buffer.Append('\f');
                            else if (c == 'n') buffer.Append('\n');
                            else if (c == 'r') buffer.Append('\r');
                            else if (c == 't') buffer.Append('\t');
                            else if (c == '"') buffer.Append('\"');
                            else
                            {
                                //We were escaping a character but this isn't a valid one
                                throw new MalformedJsonException();
                            }
                            escapingCharacter = false;
                        }
                        else
                        {
                            //Add to the buffer if inside a literal
                            buffer.Append(c);
                        }
                    }
                    else if (c == '"' && escapingCharacter && inLiteral)
                    {
                        buffer.Append('"'); escapingCharacter = false;
                    }
                }
                else if (inNestedJsonObject && c != '}')
                {
                    //Add to the buffer if inside a nested Json object
                    buffer.Append(c);
                }
                else if (char.IsWhiteSpace(c))
                { //Whitespace characters
                    if (buildingPrimitiveValue)
                    {
                        if (buffer.Length > 0)
                        {
                            jo.Put(ParseValue(buffer.ToString()));
                            buffer.Length = 0;
                            buildingPrimitiveValue = false;
                            expectingValue = false;
                        }
                    }
                }
                else if (c == '[')
                {
                    squareBracketCounter++;
                    if (squareBracketCounter == 1 && hasEnteredArray)
                    {
                        throw new MalformedJsonException();
                    }
                    hasEnteredArray = true;
                    expectingValue = true;
                }
                else if (c == ']')
                {
                    squareBracketCounter--;
                    if (squareBracketCounter < 0)
                    {
                        throw new MalformedJsonException();
                    }
                    else if (squareBracketCounter == 0)
                    {
                        //We weren't in an object and a bracket appeared
                        //The object should be ending in this case and this is the final value
                        if (buffer.Length > 0)
                        {
                            jo.Put(ParseValue(buffer.ToString()));
                            buffer.Length = 0;
                        }
                        expectingValue = false;
                    }
                }
                else if (c == '{')
                {
                    curlyBracketCounter++;
                    if (curlyBracketCounter > 0)
                    {
                        inNestedJsonObject = true;
                        buffer.Append(c);
                    }
                }
                else if (c == '}')
                {
                    curlyBracketCounter--;
                    if (curlyBracketCounter < 0)
                    {
                        throw new MalformedJsonException();
                    }
                    else if (curlyBracketCounter == 0)
                    {
                        if (inNestedJsonObject)
                        {
                            inNestedJsonObject = false;
                            buffer.Append(c);

                            //Parse the inner object and add it 
                            jo.Put(new JSONObject(buffer.ToString()));
                            buffer.Length = 0;
                        }
                    }
                }
                else if (c == '"')
                { //Here we either just started or ended a literal
                    inLiteral = !inLiteral;
                    //If we're looking for a name and we just exited a literal
                    if (!inLiteral) //If we just ended a literal...
                    {
                        //We were expecting a value so we must have a string literal
                        jo.Put(buffer.ToString()); buffer.Length = 0;
                    }
                }
                else if (c == ',')
                {
                    //This would mean we didn't enclose a literal and are looking for a value
                    //The buffer should be a value
                    if (buffer.Length > 0)
                    {
                        jo.Put(ParseValue(buffer.ToString()));
                        buffer.Length = 0;
                        expectingValue = true;
                    }
                }
                else
                {
                    //Only accept other characters if in an object and looking for a value
                    if (hasEnteredArray && expectingValue)
                    {
                        buffer.Append(c);
                        buildingPrimitiveValue = true;
                    }
                    else
                    {
                        throw new MalformedJsonException();
                    }
                }
            }

            //parse complete
            return jo;
        }

        /// <summary>
        /// Parse a value from a Json field string
        /// </summary>
        /// <param name="s">The Json field string to parse</param>
        /// <returns>A value of the parsed Json field string</returns>
        private object ParseValue(string s)
        {
            if (s == "") return null;
            if (s == null) return null;
            if (s == "true" || s == "false") return bool.Parse(s);
            if (Regex.IsMatch(s, @"^[0-9-]+$"))
            {
                try
                {
                    return int.Parse(s);
                }
                catch
                {
                    return long.Parse(s);
                }
            }
            if (Regex.IsMatch(s, @"^[0-9.-]+$"))
            {
                return double.Parse(s);
            }

            return null;
        }

    }

    /// <summary>
    /// An Exception class for generic Json related errors
    /// </summary>
    public class JsonException : Exception { }

    /// <summary>
    /// An Exception class for malformed Json errors
    /// </summary>
    public class MalformedJsonException : Exception { }

}
