function ContractListView(container, parent) {
        this.Parent = parent;
        this.Dom = {};
        this.Container = container;
        var Instance = this;

        //添加按钮
        Instance.Dom.btnAdd = $("#btnAdd", container);
        Instance.Dom.btnAdd.click(function () {
                $("#ContractDetail_Div").zxxbox();
        });
}