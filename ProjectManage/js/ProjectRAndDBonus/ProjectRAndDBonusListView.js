function ProjectRAndDBonus(container, parent) {
        this.Parent = parent;
        this.Dom = {};
        this.Container = container;
        var Instance = this;

        Instance.Dom.BtnAdd = $("#btnAdd", container);
        Instance.Dom.BtnAdd.click(function () {
                $("#ProjectRAndDBonusDetail_Div").zxxbox();
        });
}