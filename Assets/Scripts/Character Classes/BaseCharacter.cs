using UnityEngine;
using System.Collections;
using System;				//added for enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;
	
	public void Awake() {
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string Name {
		get{ return _name;}
		set{ _name = value;}
	}
	public int Level {
		get{ return _level;}
		set{ _level = value;}
	}
	public uint FreeExp {
		get{ return _freeExp;}
		set{ _freeExp = value;}
	}
	
	public void AddExp(uint exp) {
		_freeExp += exp;
		CalculateLevel();
	}
	
	//take the average of all the player's skills and assign that as the splayer level.
	public void CalculateLevel() {
		
	}
	
	private void SetupPrimaryAttributes() {
	
		for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++) {
			_primaryAttribute[cnt] = new Attribute();
		}
	
	}
	private void SetupVitals() {
		for(int cnt = 0; cnt < _vital.Length; cnt++) {
			_vital[cnt] = new Vital();
		}
	}
	private void SetupSkills() {
		for(int cnt = 0; cnt < _skill.Length; cnt++) {
			_skill[cnt] = new Skill();
		}
	}
	
	public Attribute GetPrimaryAttribute(int index) {
		return _primaryAttribute[index];
	}
	public Vital GetVital(int index) {
		return _vital[index];
	}
	public Skill GetSkill(int index) {
		return _skill[index];
	}
	
	private void SetupVitalModifiers() {
		//health
		GetVital ((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
		//energy
		GetVital ((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1));
		//mana
		GetVital ((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Focus), 1));
	}
	private void SetupSkillModifiers() {
		
		//melee offence
		GetSkill((int)SkillName.Melee).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
		GetSkill((int)SkillName.Melee).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .33f));
		
		//melee defense
		GetSkill((int)SkillName.Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));
		
		//magic offense
		GetSkill((int)SkillName.Faith).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), .33f));
		GetSkill((int)SkillName.Faith).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Focus), .33f));
		
		//magic Defense
		GetSkill((int)SkillName.Piety).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), .33f));
		GetSkill((int)SkillName.Piety).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Focus), .33f));
		
		//ranged offence
		GetSkill((int)SkillName.Targeting).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .33f));
		GetSkill((int)SkillName.Targeting).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));

		//ranged defense
		GetSkill((int)SkillName.Targeting).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .33f));
		GetSkill((int)SkillName.Targeting).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));




		
	}
	
}
