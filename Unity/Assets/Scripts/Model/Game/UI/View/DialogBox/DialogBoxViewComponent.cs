﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Model
{
    [UIBaseData(UIViewType = (int)UIViewType.Pop, PrefabPath = "Assets/Res/UI/Prefab/DialogBoxView.prefab", UIMaskMode = (int)UIMaskMode.BlackTransparentClick,
        UILayer = (int)Model.UIViewLayer.Normal)]
    public class DialogBoxViewComponent : UIBaseComponent, IOpen<DialogBoxInfo>
    {
        private Text         TextTitle;
        private Text         TextContent;
        private List<Text>   TextBtnList;
        private List<Button> BtnList;

        private DialogBoxInfo Info;

        public override void Awake()
        {
            base.Awake();

            ReferenceCollector rc = this.Entity.GameObject.GetComponent<ReferenceCollector>();
            this.TextTitle = rc.Get<GameObject>("TextTitle").GetComponent<Text>();
            this.TextContent = rc.Get<GameObject>("TextContent").GetComponent<Text>();
            var btnList = rc.Get<GameObject>("BtnList").transform;

            for (int i = 1; i < 3; i++)
            {
                var index = i;
                var textBtn = btnList.Find($"Btn{i}/TextBtn{i}").GetComponent<Text>();
                var btn = btnList.Find($"Btn{i}").GetComponent<Button>();
                this.TextBtnList.Add(textBtn);
                this.BtnList.Add(btn);

                btn.onClick.AddListener(() => OnBtnClick(index));
            }
        }

        public override void Dispose()
        {
            var len = BtnList.Count;

            for (int i = 0; i < len; i++)
            {
                this.BtnList[i].onClick.RemoveAllListeners();
            }

            BtnList = null;
            Info = null;
            base.Dispose();
        }

        public override async UniTaskVoid OnLoadComplete()
        {
            this.TextTitle.text = this.Info.title;
            this.TextContent.text = this.Info.content;
            var len = BtnList.Count;
            var count = this.Info.btnTextList.Length;

            for (int i = 0; i < len; i++)
            {
                if (i < count)
                {
                    BtnList[i].gameObject.SetActive(true);
                    TextBtnList[i].text = this.Info.btnTextList[i];
                }
                else
                {
                    BtnList[i].gameObject.SetActive(false);
                }
            }
        }

        public void Open(DialogBoxInfo a)
        {
            this.Info = a;
        }

        private void OnBtnClick(int index)
        {
            Info.btnCallList[index]?.Invoke();
        }

        protected override void OnClose()
        {
            this.Info = null;
        }
    }
}