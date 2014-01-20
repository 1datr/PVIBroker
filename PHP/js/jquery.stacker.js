
(function($){
 
    /**
     * @constructor
     */
    function Stacker (obj, options) {
    	
    	this.options = options;
 
        this.options.cellwidth = this.options.cellwidth | 35;
        this.options.cellheight = this.options.cellheight | 35;
 
        this.init(obj, this.options);
    }
 
    var table_up;
	var table_down;
	var div_rails;
    /**
     * Инициализция плагина
     *
     * @param obj
     * @param options
     */
    Stacker.prototype.init = function(obj, options) {  
        var self = this;
        var message = options.message;                  
    	
        self = $(obj);

        table_up = $('<table />');
        table_up.attr("class","rack_up");
        /*table_up.attr("cellspacing","5");
        table_up.attr("cellpadding","5");*/
        //table_up.attr("border",1);
        table_up.appendTo(self);
        
        div_rails = $('<div />');
        div_rails.attr("class","stacker_rails");
        div_rails.css({"height":20});
        div_rails.appendTo(self);
        
        table_down = $('<table />');
        table_down.attr("class","rack_down");
        //table_down.attr("cellspacing","5");
        //table_down.attr("border",1);
        table_down.appendTo(self);
        
        for(y=0;y<options.Floors;y++)
    	{
	    	tr = $('<tr />');
	    	tr2 = $('<tr />');
	    	for(x=0;x<options.Rows;x++)
	    	{
	    		td = $('<td />');
	    		td.appendTo(tr);  
	    		//td.attr("width",this.options.cellwidth);
	    		
	    		td2 = $('<td />');
	    		td2.appendTo(tr2);
	    		//td2.attr("width",this.options.cellwidth);
	    	}
	    	tr.appendTo(table_up);
	    	//tr.attr("height",this.options.cellheight);
	    	
	    	tr2.appendTo(table_down);
	    	//tr2.attr("height",this.options.cellheight);
    	}
        
        var rows = $('.rack_up tr');
        var cols = $('.rack_up tr td');
        var ncell = 0;
        for(x=0;x<cols.length;x++)
        	{
        	for(y=rows.length-1;y>=0;y--)
        		{
        		$(".rack_up tr:eq("+y+") td:eq("+x+")").html(ncell);
        		ncell++;
        		}
        	}
        
        for(x=0;x<cols.length;x++)
    		{
	    	for(y=0;y<rows.length;y++)
	    		{
	    		$(".rack_down tr:eq("+y+") td:eq("+x+")").html(ncell);
	    		ncell++;
	    		}
    		}
    };
 
    /**
     * Показываем сообщение
     */
    Stacker.prototype.showMessage = function(message) {        
        alert(message);
    };
 
    /**
     * Тело плагина
     * @param options
     */
    $.fn.Stacker = function(options) {
        $.Stacker = new Stacker($(this), options);
    };
 
})($);