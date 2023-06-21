using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Editor
{
    public class GameplayCharacterCustomizationManagerScript : MonoBehaviour
    {
        //Center Body Parts
        [SerializeField]
        Sprite[] HeadCollection;
        [SerializeField]
        SpriteRenderer Head;
        [SerializeField]
        Sprite[] TorsoCollection;
        [SerializeField]
        SpriteRenderer Torso;
        [SerializeField]
        Sprite[] PelvisCollection;
        [SerializeField]
        SpriteRenderer Pelvis;

        int HeadCount;
        int TorsoCount;
        int PelvisCount;

        //Left Body Parts
        [SerializeField]
        Sprite[] LeftUpperArmCollection;
        [SerializeField]
        SpriteRenderer LeftUpperArm;
        [SerializeField]
        Sprite[] LeftLowerArmCollection;
        [SerializeField]
        SpriteRenderer LeftLowerArm;
        [SerializeField]
        Sprite[] LeftUpperLegCollection;
        [SerializeField]
        SpriteRenderer LeftUpperLeg;
        [SerializeField]
        Sprite[] LeftLowerLegCollection;
        [SerializeField]
        SpriteRenderer LeftLowerLeg;

        int LeftUpperArmCount;
        int LeftLowerArmCount;
        int LeftUpperLegCount;
        int LeftLowerLegCount;

        //Right Body Parts
        [SerializeField]
        Sprite[] RightUpperArmCollection;
        [SerializeField]
        SpriteRenderer RightUpperArm;
        [SerializeField]
        Sprite[] RightLowerArmCollection;
        [SerializeField]
        SpriteRenderer RightLowerArm;
        [SerializeField]
        Sprite[] RightUpperLegCollection;
        [SerializeField]
        SpriteRenderer RightUpperLeg;
        [SerializeField]
        Sprite[] RightLowerLegCollection;
        [SerializeField]
        SpriteRenderer RightLowerLeg;

        int RightUpperArmCount;
        int RightLowerArmCount;
        int RightUpperLegCount;
        int RightLowerLegCount;

        //Character
        //int CharacterCount;

        // Character Gender Icon
        //[SerializeField]
        //GameObject MaleIcon;
        //[SerializeField]
        //GameObject Femalecon;
        //[SerializeField]
        //GameObject UniIcon;

        //Switch Body Selection

        //int CenterBodyPartsCount;
        //[SerializeField]
        //GameObject[] CenterBodyPartsCollection;
        //[SerializeField]
        //Button[] CenterBodyPartsButton;

        //int LeftBodyArmCount;
        //[SerializeField]
        //GameObject[] LeftBodyArmCollection;
        //[SerializeField]
        //Button[] LeftBodyArmButton;



        //int LeftBodyLegCount;
        //[SerializeField]
        //GameObject[] LeftBodyLegCollection;
        //[SerializeField]
        //Button[] LeftBodyLegButton;

        //int RightBodyArmCount;
        //[SerializeField]
        //GameObject[] RightBodyArmCollection;
        //[SerializeField]
        //Button[] RightBodyArmButton;

        //int RightBodyLegCount;
        //[SerializeField]
        //GameObject[] RightBodyLegCollection;
        //[SerializeField]
        //Button[] RightBodyLegButton;


        private void Awake()
        {
            HeadCount = PlayerPrefs.GetInt("Head");
            TorsoCount = PlayerPrefs.GetInt("Torso");
            PelvisCount = PlayerPrefs.GetInt("Pelvis");

            LeftUpperArmCount = PlayerPrefs.GetInt("L U Arm");
            LeftLowerArmCount = PlayerPrefs.GetInt("L L Arm");
            LeftUpperLegCount = PlayerPrefs.GetInt("L U Leg");
            LeftLowerLegCount = PlayerPrefs.GetInt("L L Leg");

            RightUpperArmCount = PlayerPrefs.GetInt("R U Arm");
            RightLowerArmCount = PlayerPrefs.GetInt("R L Arm");
            RightUpperLegCount = PlayerPrefs.GetInt("R U Leg");
            RightLowerLegCount = PlayerPrefs.GetInt("R L Leg");

            for (int i = 0; i < HeadCollection.Length; i++)
            {
                Head.sprite = HeadCollection[HeadCount];
            }

            for (int i = 0; i < TorsoCollection.Length; i++)
            {
                Torso.sprite = TorsoCollection[TorsoCount];
            }

            for (int i = 0; i < PelvisCollection.Length; i++)
            {
                Pelvis.sprite = PelvisCollection[PelvisCount];
            }

            for (int i = 0; i < LeftUpperArmCollection.Length; i++)
            {
                LeftUpperArm.sprite = LeftUpperArmCollection[LeftUpperArmCount];
            }

            for (int i = 0; i < LeftLowerArmCollection.Length; i++)
            {
                LeftLowerArm.sprite = LeftLowerArmCollection[LeftLowerArmCount];
            }

            for (int i = 0; i < RightUpperArmCollection.Length; i++)
            {
                RightUpperArm.sprite = RightUpperArmCollection[RightUpperArmCount];
            }

            for (int i = 0; i < RightLowerArmCollection.Length; i++)
            {
                RightLowerArm.sprite = RightLowerArmCollection[RightLowerArmCount];
            }

            for (int i = 0; i < LeftUpperLegCollection.Length; i++)
            {
                LeftUpperLeg.sprite = LeftUpperLegCollection[LeftUpperLegCount];
            }

            for (int i = 0; i < LeftLowerLegCollection.Length; i++)
            {
                LeftLowerLeg.sprite = LeftLowerLegCollection[LeftLowerLegCount];
            }

            for (int i = 0; i < RightUpperLegCollection.Length; i++)
            {
                RightUpperLeg.sprite = RightUpperLegCollection[RightUpperLegCount];
            }

            for (int i = 0; i < RightLowerLegCollection.Length; i++)
            {
                RightLowerLeg.sprite = RightLowerLegCollection[RightLowerLegCount];
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //GenderIconCheck();
            //SwitchBodyCheck();
        }

        //void GenderIconCheck()
        //{

        //    if ((HeadCount == 0) && (TorsoCount == 0) && (PelvisCount == 0) && (LeftLowerArmCount == 0) && (LeftUpperArmCount == 0) && (LeftLowerLegCount == 0) && (LeftUpperLegCount == 0) && (RightLowerArmCount == 0) && (RightUpperArmCount == 0) && (RightLowerLegCount == 0) && (RightUpperLegCount == 0))
        //    {
        //        MaleIcon.gameObject.SetActive(true);
        //        Femalecon.gameObject.SetActive(false);
        //        UniIcon.gameObject.SetActive(false);
        //    }

        //    else
        //    {
        //        MaleIcon.gameObject.SetActive(false);
        //        Femalecon.gameObject.SetActive(false);
        //        UniIcon.gameObject.SetActive(true);
        //    }


        //    if ((HeadCount == 3) && (TorsoCount == 3) && (PelvisCount == 3) && (LeftLowerArmCount == 3) && (LeftUpperArmCount == 3) && (LeftLowerLegCount == 3) && (LeftUpperLegCount == 3) && (RightLowerArmCount == 3) && (RightUpperArmCount == 3) && (RightLowerLegCount == 3) && (RightUpperLegCount == 3))
        //        {
        //            MaleIcon.gameObject.SetActive(false);
        //            Femalecon.gameObject.SetActive(true);
        //            UniIcon.gameObject.SetActive(false);
        //        }
        //}

        //void SwitchBodyCheck()
        //{
        //    if (CenterBodyPartsCount == 0)
        //    {
        //        CenterBodyPartsButton[0].interactable = false;
        //        CenterBodyPartsButton[1].interactable = true;
        //    }

        //    if (CenterBodyPartsCount == 1)
        //    {
        //        CenterBodyPartsButton[0].interactable = true;
        //        CenterBodyPartsButton[1].interactable = true;
        //    }

        //    if (CenterBodyPartsCount == 2)
        //    {
        //        CenterBodyPartsButton[0].interactable = true;
        //        CenterBodyPartsButton[1].interactable = false;
        //    }

        //    if (LeftBodyArmCount == 0)
        //    {
        //        LeftBodyArmButton[0].interactable = false;
        //        LeftBodyArmButton[1].interactable = true;
        //    }

        //    if (LeftBodyArmCount == 1)
        //    {
        //        LeftBodyArmButton[0].interactable = true;
        //        LeftBodyArmButton[1].interactable = false;
        //    }

        //    if (LeftBodyLegCount == 0)
        //    {
        //        LeftBodyLegButton[0].interactable = false;
        //        LeftBodyLegButton[1].interactable = true;
        //    }

        //    if (LeftBodyLegCount == 1)
        //    {
        //        LeftBodyLegButton[0].interactable = true;
        //        LeftBodyLegButton[1].interactable = false;
        //    }

        //    //

        //    if (RightBodyArmCount == 0)
        //    {
        //        RightBodyArmButton[0].interactable = false;
        //        RightBodyArmButton[1].interactable = true;
        //    }

        //    if (RightBodyArmCount == 1)
        //    {
        //        RightBodyArmButton[0].interactable = true;
        //        RightBodyArmButton[1].interactable = false;
        //    }

        //    if (RightBodyLegCount == 0)
        //    {
        //        RightBodyLegButton[0].interactable = false;
        //        RightBodyLegButton[1].interactable = true;
        //    }

        //    if (RightBodyLegCount == 1)
        //    {
        //        RightBodyLegButton[0].interactable = true;
        //        RightBodyLegButton[1].interactable = false;
        //    }
        //}

        //public void BodyButtonControl(int BodyID)
        //{
        //    SoundEffect();
        //    //Center Body
        //    if (BodyID == 0)
        //    {
        //        CenterBodyPartsCount += 1;

        //        foreach(GameObject CB in CenterBodyPartsCollection)
        //        {
        //            CB.gameObject.SetActive(false);
        //        }

        //        CenterBodyPartsCollection[CenterBodyPartsCount].gameObject.SetActive(true);
        //    }

        //    if (BodyID == 1)
        //    {
        //        CenterBodyPartsCount -= 1;

        //        foreach (GameObject CB in CenterBodyPartsCollection)
        //        {
        //            CB.gameObject.SetActive(false);
        //        }

        //        CenterBodyPartsCollection[CenterBodyPartsCount].gameObject.SetActive(true);
        //    }

        //    //Left Arm
        //    if (BodyID == 2)
        //    {
        //        LeftBodyArmCount += 1;

        //        foreach (GameObject LBA in LeftBodyArmCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        LeftBodyArmCollection[LeftBodyArmCount].gameObject.SetActive(true);
        //    }

        //    if (BodyID == 3)
        //    {
        //        LeftBodyArmCount -= 1;

        //        foreach (GameObject LBA in LeftBodyArmCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        LeftBodyArmCollection[LeftBodyArmCount].gameObject.SetActive(true);
        //    }

        //    //Left Leg
        //    if (BodyID == 4)
        //    {
        //        LeftBodyLegCount += 1;

        //        foreach (GameObject LBA in LeftBodyLegCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        LeftBodyLegCollection[LeftBodyLegCount].gameObject.SetActive(true);
        //    }

        //    if (BodyID == 5)
        //    {
        //        LeftBodyLegCount -= 1;

        //        foreach (GameObject LBA in LeftBodyLegCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        LeftBodyLegCollection[LeftBodyLegCount].gameObject.SetActive(true);
        //    }

        //    //Right Arm
        //    if (BodyID == 6)
        //    {
        //        RightBodyArmCount += 1;

        //        foreach (GameObject LBA in RightBodyArmCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        RightBodyArmCollection[RightBodyArmCount].gameObject.SetActive(true);
        //    }

        //    if (BodyID == 7)
        //    {
        //        RightBodyArmCount -= 1;

        //        foreach (GameObject LBA in RightBodyArmCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        RightBodyArmCollection[RightBodyArmCount].gameObject.SetActive(true);
        //    }

        //    //Right Leg
        //    if (BodyID == 8)
        //    {
        //        RightBodyLegCount += 1;

        //        foreach (GameObject LBA in RightBodyLegCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        RightBodyLegCollection[RightBodyLegCount].gameObject.SetActive(true);
        //    }

        //    if (BodyID == 9)
        //    {
        //        RightBodyLegCount -= 1;

        //        foreach (GameObject LBA in RightBodyLegCollection)
        //        {
        //            LBA.gameObject.SetActive(false);
        //        }

        //        RightBodyLegCollection[RightBodyLegCount].gameObject.SetActive(true);
        //    }

        //}
        public void HeadButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < HeadCollection.Length; i++)
            {
                IdMaxCount = i;
            }
            
            if (HeadCount == IdMaxCount)
            {
                HeadCount = 0;
            }
            else
            {
                HeadCount += 1;
            }


            for (int i = 0; i < HeadCollection.Length; i++)
            {
                Head.sprite = HeadCollection[HeadCount];
            }
        }

        public void TorsoButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < TorsoCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (TorsoCount == IdMaxCount)
            {
                TorsoCount = 0;
            }
            else
            {
                TorsoCount += 1;
            }


            for (int i = 0; i < TorsoCollection.Length; i++)
            {
                Torso.sprite = TorsoCollection[TorsoCount];
            }
        }

        public void PelvisButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < PelvisCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (PelvisCount == IdMaxCount)
            {
                PelvisCount = 0;
            }
            else
            {
                PelvisCount += 1;
            }


            for (int i = 0; i < PelvisCollection.Length; i++)
            {
                Pelvis.sprite = PelvisCollection[PelvisCount];
            }
        }

        public void LeftUpperArmButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < LeftUpperArmCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (LeftUpperArmCount == IdMaxCount)
            {
                LeftUpperArmCount = 0;
            }
            else
            {
                LeftUpperArmCount += 1;
            }


            for (int i = 0; i < LeftUpperArmCollection.Length; i++)
            {
                LeftUpperArm.sprite = LeftUpperArmCollection[LeftUpperArmCount];
            }
        }

        public void LeftLowerArmButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < LeftLowerArmCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (LeftLowerArmCount == IdMaxCount)
            {
                LeftLowerArmCount = 0;
            }
            else
            {
                LeftLowerArmCount += 1;
            }


            for (int i = 0; i < LeftLowerArmCollection.Length; i++)
            {
                LeftLowerArm.sprite = LeftLowerArmCollection[LeftLowerArmCount];
            }
        }

        public void RightUpperArmButtonControl(int IdMaxCount)
        {

            //SoundEffect();
            for (int i = 0; i < RightUpperArmCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (RightUpperArmCount == IdMaxCount)
            {
                RightUpperArmCount = 0;
            }
            else
            {
                RightUpperArmCount += 1;
            }


            for (int i = 0; i < RightUpperArmCollection.Length; i++)
            {
                RightUpperArm.sprite = RightUpperArmCollection[RightUpperArmCount];
            }
        }

        public void RightLowerArmButtonControl(int IdMaxCount)
        {
            //SoundEffect();

            for (int i = 0; i < RightLowerArmCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (RightLowerArmCount == IdMaxCount)
            {
                RightLowerArmCount = 0;
            }
            else
            {
                RightLowerArmCount += 1;
            }


            for (int i = 0; i < RightLowerArmCollection.Length; i++)
            {
                RightLowerArm.sprite = RightLowerArmCollection[RightLowerArmCount];
            }
        }

        public void LeftUpperLegButtonControl(int IdMaxCount)
        {
            //SoundEffect();

            for (int i = 0; i < LeftUpperLegCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (LeftUpperLegCount == IdMaxCount)
            {
                LeftUpperLegCount = 0;
            }
            else
            {
                LeftUpperLegCount += 1;
            }


            for (int i = 0; i < LeftUpperLegCollection.Length; i++)
            {
                LeftUpperLeg.sprite = LeftUpperLegCollection[LeftUpperLegCount];
            }
        }

        public void LeftLowerLegButtonControl(int IdMaxCount)
        {
            //SoundEffect();

            for (int i = 0; i < LeftLowerLegCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (LeftLowerLegCount == IdMaxCount)
            {
                LeftLowerLegCount = 0;
            }
            else
            {
                LeftLowerLegCount += 1;
            }


            for (int i = 0; i < LeftLowerLegCollection.Length; i++)
            {
                LeftLowerLeg.sprite = LeftLowerLegCollection[LeftLowerLegCount];
            }
        }

        public void RightUpperLegButtonControl(int IdMaxCount)
        {
           // SoundEffect();

            for (int i = 0; i < RightUpperLegCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (RightUpperLegCount == IdMaxCount)
            {
                RightUpperLegCount = 0;
            }
            else
            {
                RightUpperLegCount += 1;
            }


            for (int i = 0; i < RightUpperLegCollection.Length; i++)
            {
                RightUpperLeg.sprite = RightUpperLegCollection[RightUpperLegCount];
            }
        }
        public void RightLowerLegButtonControl(int IdMaxCount)
        {
            //SoundEffect();

            for (int i = 0; i < RightLowerLegCollection.Length; i++)
            {
                IdMaxCount = i;
            }

            if (RightLowerLegCount == IdMaxCount)
            {
                RightLowerLegCount = 0;
            }
            else
            {
                RightLowerLegCount += 1;
            }


            for (int i = 0; i < RightLowerLegCollection.Length; i++)
            {
                RightLowerLeg.sprite = RightLowerLegCollection[RightLowerLegCount];
            }
        }

        //public void RandomButtonControl()
        //{
        //    SoundEffect();
        //    HeadCount = Random.Range(0, HeadCollection.Length);
        //    TorsoCount = Random.Range(0, TorsoCollection.Length);
        //    PelvisCount = Random.Range(0, PelvisCollection.Length);
        //    LeftUpperArmCount = Random.Range(0, LeftUpperArmCollection.Length);
        //    LeftLowerArmCount = Random.Range(0, LeftLowerArmCollection.Length);
        //    LeftUpperLegCount = Random.Range(0, LeftUpperLegCollection.Length);
        //    LeftLowerLegCount = Random.Range(0, LeftLowerLegCollection.Length);
        //    RightUpperArmCount = Random.Range(0, RightUpperArmCollection.Length);
        //    RightLowerArmCount = Random.Range(0, RightLowerArmCollection.Length);
        //    RightUpperLegCount = Random.Range(0, RightUpperLegCollection.Length);
        //    RightLowerLegCount = Random.Range(0, RightLowerLegCollection.Length);

        //    for (int i = 0; i < HeadCollection.Length; i++)
        //    {
        //        Head.sprite = HeadCollection[HeadCount];
        //    }

        //    for (int i = 0; i < TorsoCollection.Length; i++)
        //    {
        //        Torso.sprite = TorsoCollection[TorsoCount];
        //    }

        //    for (int i = 0; i < PelvisCollection.Length; i++)
        //    {
        //        Pelvis.sprite = PelvisCollection[PelvisCount];
        //    }

        //    for (int i = 0; i < LeftUpperArmCollection.Length; i++)
        //    {
        //        LeftUpperArm.sprite = LeftUpperArmCollection[LeftUpperArmCount];
        //    }

        //    for (int i = 0; i < LeftLowerArmCollection.Length; i++)
        //    {
        //        LeftLowerArm.sprite = LeftLowerArmCollection[LeftLowerArmCount];
        //    }


        //    for (int i = 0; i < RightUpperArmCollection.Length; i++)
        //    {
        //        RightUpperArm.sprite = RightUpperArmCollection[RightUpperArmCount];
        //    }

        //    for (int i = 0; i < RightLowerArmCollection.Length; i++)
        //    {
        //        RightLowerArm.sprite = RightLowerArmCollection[RightLowerArmCount];
        //    }

        //    for (int i = 0; i < LeftUpperLegCollection.Length; i++)
        //    {
        //        LeftUpperLeg.sprite = LeftUpperLegCollection[LeftUpperLegCount];
        //    }

        //    for (int i = 0; i < LeftLowerLegCollection.Length; i++)
        //    {
        //        LeftLowerLeg.sprite = LeftLowerLegCollection[LeftLowerLegCount];
        //    }

        //    for (int i = 0; i < RightUpperLegCollection.Length; i++)
        //    {
        //        RightUpperLeg.sprite = RightUpperLegCollection[RightUpperLegCount];
        //    }

        //    for (int i = 0; i < RightLowerLegCollection.Length; i++)
        //    {
        //        RightLowerLeg.sprite = RightLowerLegCollection[RightLowerLegCount];
        //    }
        //}

        //public void CharacterButtonControl()
        //{
        //    SoundEffect();
        //    if (CharacterCount == 2)
        //    {
        //        CharacterCount = 0;
        //    }
        //    else
        //    {
        //        CharacterCount += 1;
        //    }

        //    if (CharacterCount == 0)
        //    {
        //        HeadCount = 0;
        //        TorsoCount = 0;
        //        PelvisCount = 0;

        //        LeftUpperArmCount = 0;
        //        LeftLowerArmCount = 0;
        //        LeftUpperLegCount = 0;
        //        LeftLowerLegCount = 0;

        //        RightUpperArmCount = 0;
        //        RightLowerArmCount = 0;
        //        RightUpperLegCount = 0;
        //        RightLowerLegCount = 0;

        //        for (int i = 0; i < HeadCollection.Length; i++)
        //        {
        //            Head.sprite = HeadCollection[0];
        //        }

        //        for (int i = 0; i < TorsoCollection.Length; i++)
        //        {
        //            Torso.sprite = TorsoCollection[0];
        //        }

        //        for (int i = 0; i < PelvisCollection.Length; i++)
        //        {
        //            Pelvis.sprite = PelvisCollection[0];
        //        }

        //        for (int i = 0; i < LeftUpperArmCollection.Length; i++)
        //        {
        //            LeftUpperArm.sprite = LeftUpperArmCollection[0];
        //        }

        //        for (int i = 0; i < LeftLowerArmCollection.Length; i++)
        //        {
        //            LeftLowerArm.sprite = LeftLowerArmCollection[0];
        //        }


        //        for (int i = 0; i < RightUpperArmCollection.Length; i++)
        //        {
        //            RightUpperArm.sprite = RightUpperArmCollection[0];
        //        }

        //        for (int i = 0; i < RightLowerArmCollection.Length; i++)
        //        {
        //            RightLowerArm.sprite = RightLowerArmCollection[0];
        //        }

        //        for (int i = 0; i < LeftUpperLegCollection.Length; i++)
        //        {
        //            LeftUpperLeg.sprite = LeftUpperLegCollection[0];
        //        }

        //        for (int i = 0; i < LeftLowerLegCollection.Length; i++)
        //        {
        //            LeftLowerLeg.sprite = LeftLowerLegCollection[0];
        //        }

        //        for (int i = 0; i < RightUpperLegCollection.Length; i++)
        //        {
        //            RightUpperLeg.sprite = RightUpperLegCollection[0];
        //        }

        //        for (int i = 0; i < RightLowerLegCollection.Length; i++)
        //        {
        //            RightLowerLeg.sprite = RightLowerLegCollection[0];
        //        }
        //    }

        //    if (CharacterCount == 1)
        //    {
        //        HeadCount = 3;
        //        TorsoCount = 3;
        //        PelvisCount = 3;

        //        LeftUpperArmCount = 3;
        //        LeftLowerArmCount = 3;
        //        LeftUpperLegCount = 3;
        //        LeftLowerLegCount = 3;

        //        RightUpperArmCount = 3;
        //        RightLowerArmCount = 3;
        //        RightUpperLegCount = 3;
        //        RightLowerLegCount = 3;

        //        for (int i = 0; i < HeadCollection.Length; i++)
        //        {
        //            Head.sprite = HeadCollection[3];
        //        }

        //        for (int i = 0; i < TorsoCollection.Length; i++)
        //        {
        //            Torso.sprite = TorsoCollection[3];
        //        }

        //        for (int i = 0; i < PelvisCollection.Length; i++)
        //        {
        //            Pelvis.sprite = PelvisCollection[3];
        //        }

        //        for (int i = 0; i < LeftUpperArmCollection.Length; i++)
        //        {
        //            LeftUpperArm.sprite = LeftUpperArmCollection[3];
        //        }

        //        for (int i = 0; i < LeftLowerArmCollection.Length; i++)
        //        {
        //            LeftLowerArm.sprite = LeftLowerArmCollection[3];
        //        }


        //        for (int i = 0; i < RightUpperArmCollection.Length; i++)
        //        {
        //            RightUpperArm.sprite = RightUpperArmCollection[3];
        //        }

        //        for (int i = 0; i < RightLowerArmCollection.Length; i++)
        //        {
        //            RightLowerArm.sprite = RightLowerArmCollection[3];
        //        }

        //        for (int i = 0; i < LeftUpperLegCollection.Length; i++)
        //        {
        //            LeftUpperLeg.sprite = LeftUpperLegCollection[3];
        //        }

        //        for (int i = 0; i < LeftLowerLegCollection.Length; i++)
        //        {
        //            LeftLowerLeg.sprite = LeftLowerLegCollection[3];
        //        }

        //        for (int i = 0; i < RightUpperLegCollection.Length; i++)
        //        {
        //            RightUpperLeg.sprite = RightUpperLegCollection[3];
        //        }

        //        for (int i = 0; i < RightLowerLegCollection.Length; i++)
        //        {
        //            RightLowerLeg.sprite = RightLowerLegCollection[3];
        //        }
        //    }

        //    if (CharacterCount == 2)
        //    {
        //        RandomButtonControl();
        //    }
        //}

        //public void SaveButton()
        //{
        //    SoundEffect();
        //    PlayerPrefs.SetInt("Head", HeadCount);
        //    PlayerPrefs.SetInt("Torso", TorsoCount);
        //    PlayerPrefs.SetInt("Pelvis", PelvisCount);
        //    PlayerPrefs.SetInt("L U Arm", LeftUpperArmCount);
        //    PlayerPrefs.SetInt("L L Arm", LeftLowerArmCount);
        //    PlayerPrefs.SetInt("L U Leg", LeftUpperLegCount);
        //    PlayerPrefs.SetInt("L L Leg", LeftLowerLegCount);
        //    PlayerPrefs.SetInt("R U Arm", RightUpperArmCount);
        //    PlayerPrefs.SetInt("R L Arm", RightLowerArmCount);
        //    PlayerPrefs.SetInt("R U Leg", RightUpperLegCount);
        //    PlayerPrefs.SetInt("R L Leg", RightLowerLegCount);

        //}
        //public void HidePanel(GameObject gameObjectID)
        //{
        //    gameObjectID.gameObject.SetActive(false);
        //}

        //public void ShowPanel(GameObject gameObjectID)
        //{
        //    gameObjectID.gameObject.SetActive(true);
        //}

        //void SoundEffect()
        //{
        //    SoundEffectScript.instance.Play(SoundEffectScript.instance.SoundButton);
        //}
    }
}

