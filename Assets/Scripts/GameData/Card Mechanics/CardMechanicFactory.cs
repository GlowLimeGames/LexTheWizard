/*
 * Author: Isaiah Mann
 * Description: Parses card mechanics from JSON
 */

using System;
using System.Reflection;
using SimpleJSON;

public class CardMechanicFactory : LTWData {
	const string ID = "ID";
	const string TYPE = "Type";
	const string VARIANT = "Variant";
	const string DELAY = "Effect Delay";
	const string DURATION = "Effect Duration";
	const string POWER = "Effect Power";
	const string DELEGATES = "Delegates";
	const string SUPER_CLASS = "CardMechanic";

	public CardMechanic GetMechanic (string json) {
		JSONNode node = JSON.Parse(json);
		string id = node[ID];
		string variantType =  node[VARIANT];
		MechanicType type = (MechanicType) Enum.Parse(typeof(MechanicType), node[TYPE]);
		int delay = node[DELAY].AsInt;
		int duration = node[DURATION].AsInt;
		int power = node[POWER].AsInt;
		string[] delegates = JSONToStringArray(node[DELEGATES].AsArray);
		MechanicStats stats = new MechanicStats(id, type, delegates);
		Type classType = Type.GetType(getClassName(variantType));
		ConstructorInfo constructor = classType.GetConstructor(new Type[]{typeof(MechanicStats)});
		return constructor.Invoke(new object[]{stats}) as CardMechanic;
	}

	public CardMechanic GetMechanic (MechanicVariant variant, MechanicStats stats) {
		Type classType = Type.GetType(getClassName(variant.ToString()));
		ConstructorInfo constructor = classType.GetConstructor(new Type[]{typeof(MechanicStats)});
		return constructor.Invoke(new object[]{stats}) as CardMechanic;
	}

	string getClassName (string variantType) {
		return string.Format("{0}{1}", variantType, SUPER_CLASS);
	}
}
